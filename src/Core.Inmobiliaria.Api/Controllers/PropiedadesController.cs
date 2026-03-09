using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
//using MediatR;
using Microsoft.AspNetCore.Mvc;
//using Core.Inmobiliaria.Api.Commands.Propiedades;



namespace Core.Inmobiliaria.Api.Controllers
{    
[ApiController]
[Route("api/[controller]")]
    public class PropiedadesController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok(new { Id = id, Mensaje = "Propiedad encontrada (mock)" });
        }

        [HttpPost]
        public IActionResult CrearPropiedad([FromBody] CrearPropiedadRequest request)
        {
            return Created("", new { Mensaje = "Propiedad creada (mock)" });
        }
    }    
}
public record CrearPropiedadRequest(
    string CodigoInterno,
    string Direccion,
    decimal Precio,
    Guid SucursalId
);