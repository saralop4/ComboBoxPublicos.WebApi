using ComboBoxPublicos.WebApi.Dominio.DTOs;
using ComboBoxPublicos.WebApi.Dominio.Interfaces;
using ComboBoxPublicos.WebApi.Dominio.Persistencia;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ComboBoxPublicos.WebApi.Infraestructura.Repositorios;

public class CiudadRepositorio : ICiudadRepositorio
{
    private readonly DapperContext _context;
    public CiudadRepositorio(IConfiguration configuration)
    {
        _context = new DapperContext(configuration);
    }
    public async Task<IEnumerable<CiudadDto>> ObtenerTodo()
    {
        using (var conexion = _context.CreateConnection())
        {
            var query = "ObtenerCiudadesYPaises";
            var parameters = new DynamicParameters();
            var ciudades = await conexion.QueryAsync<CiudadDto>(query, commandType: CommandType.StoredProcedure);
            return ciudades.ToList();
        }
    }
}
