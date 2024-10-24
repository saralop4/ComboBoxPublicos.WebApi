using ComboBoxPublicos.WebApi.Dominio.DTOs;
using ComboBoxPublicos.WebApi.Dominio.Interfaces;
using ComboBoxPublicos.WebApi.Dominio.Persistencia;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace ComboBoxPublicos.WebApi.Infraestructura.Repositorios;
public class IndicativoRepositorio : IIndicativoRepositorio
{
    private readonly DapperContext _context;
    public IndicativoRepositorio(IConfiguration configuration)
    {
        _context = new DapperContext(configuration);
    }

    public async Task<IEnumerable<IndicativoDto>> ObtenerTodo()
    {
        using (var conexion = _context.CreateConnection())
        {
            var query = "SELECT * FROM Indicativos";
            var resultado = await conexion.QueryAsync<IndicativoDto>(query);

            return resultado;
        }
    }

}
