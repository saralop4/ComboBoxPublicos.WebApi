using ComboBoxPublicos.WebApi.Dominio.DTOs;

namespace ComboBoxPublicos.WebApi.Dominio.Interfaces;
public interface ICiudadRepositorio
{
    Task<IEnumerable<CiudadDto>> ObtenerTodo();    
}
