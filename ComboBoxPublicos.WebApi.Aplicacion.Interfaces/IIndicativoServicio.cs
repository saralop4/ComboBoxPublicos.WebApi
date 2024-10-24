using ComboBoxPublicos.WebApi.Dominio.DTOs;
using ComboBoxPublicos.WebApi.Transversal.Modelos;

namespace ComboBoxPublicos.WebApi.Aplicacion.Interfaces;

public interface IIndicativoServicio
{
    Task<Response<IEnumerable<IndicativoDto>>> ObtenerTodos();

}
