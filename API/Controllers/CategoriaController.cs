using Application.Interfaces;
using Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
    private readonly ICategoriaService _service;

    public CategoriaController(ICategoriaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categorias = await _service.ObtenerTodasAsync();
        return Ok(categorias);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var categoria = await _service.ObtenerPorIdAsync(id);
        return Ok(categoria);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CategoriaDto dto)
    {
        var id = await _service.CrearAsync(dto.Nombre);
        return CreatedAtAction(nameof(Get), new { id }, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] CategoriaDto dto)
    {
        await _service.ActualizarAsync(id, dto.Nombre);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.EliminarAsync(id);
        return NoContent();
    }
}

