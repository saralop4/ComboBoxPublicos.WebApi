﻿using ComboBoxPublicos.WebApi.Aplicacion.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ComboBoxPublicos.WebApi.Controllers.V1;

[Route("Api/V1.0/[controller]")]
[ApiController]
//[ApiVersion("1.0")]
public class IndicativoController : ControllerBase
{
    private readonly IIndicativoServicio _indicativoServicio;
    public IndicativoController(IIndicativoServicio indicativoServicio)
    {
        _indicativoServicio = indicativoServicio;

    }

    [HttpGet("ObtenerIndicativos")]
    public async Task<IActionResult> ObtenerIndicativos()
    {
        var response = await _indicativoServicio.ObtenerTodos();

        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(response);

    }
}