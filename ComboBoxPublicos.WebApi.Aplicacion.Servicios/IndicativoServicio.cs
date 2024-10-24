﻿using ComboBoxPublicos.WebApi.Aplicacion.Interfaces;
using ComboBoxPublicos.WebApi.Dominio.DTOs;
using ComboBoxPublicos.WebApi.Dominio.Interfaces;
using ComboBoxPublicos.WebApi.Transversal.Interfaces;
using ComboBoxPublicos.WebApi.Transversal.Modelos;

namespace ComboBoxPublicos.WebApi.Aplicacion.Servicios;

public class IndicativoServicio : IIndicativoServicio
{
    private readonly IIndicativoRepositorio _indicativoRepositorio;
    private readonly IAppLogger<IndicativoServicio> _logger;

    public IndicativoServicio(IIndicativoRepositorio indicativoRepositorio,IAppLogger<IndicativoServicio> logger)
    {
        _indicativoRepositorio = indicativoRepositorio;
        _logger = logger;

    }

    public async Task<Response<IEnumerable<IndicativoDto>>> ObtenerTodos()
    {
        var response = new Response<IEnumerable<IndicativoDto>>();

        try
        {
            var resultado = await _indicativoRepositorio.ObtenerTodo();

            if (resultado != null && resultado.Any())
            {
                response.Data = resultado;
                response.IsSuccess = true;
                _logger.LogInformation("Consulta exitosa!!");
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "No hay información disponible";
                _logger.LogInformation("La consulta de obtener todo de base de datos está vacia");
            }
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = $"Ocurrió un error: {ex.Message}";
            _logger.LogError(ex.Message);
        }

        return response;
    }
}
