using ComboBoxPublicos.WebApi.Aplicacion.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ComboBoxPublicos.WebApi.Controllers.V1;

[Route("Api/V1.0/[controller]")]
[ApiController]
//[ApiVersion("1.0")]
public class CiudadController : ControllerBase
{
    private readonly ICiudadServicio _ciudadServicio;

    public CiudadController(ICiudadServicio ciudadServicio)
    {
        _ciudadServicio = ciudadServicio;   
    }

    [HttpGet("ObtenerCiudades")]
    public async Task<IActionResult> ObtenerCiudades()
    {
        var response = await _ciudadServicio.ObtenerTodos();

        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(response);

    }
}