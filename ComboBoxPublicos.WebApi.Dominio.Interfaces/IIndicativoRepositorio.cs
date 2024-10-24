using ComboBoxPublicos.WebApi.Dominio.DTOs;

namespace ComboBoxPublicos.WebApi.Dominio.Interfaces;
public interface IIndicativoRepositorio
{
    Task<IEnumerable<IndicativoDto>> ObtenerTodo();


}
