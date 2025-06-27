using Application.Commands;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TuSolucion.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductoController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // POST: api/producto
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductoCommand command)
    {
        var producto = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = producto.Id }, producto);
    }

    // GET: api/producto/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var producto = await _mediator.Send(new GetProductoByIdQuery(id));
        return producto is null ? NotFound() : Ok(producto);
    }

    // GET: api/producto
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var productos = await _mediator.Send(new GetAllProductosQuery());
        return Ok(productos);
    }

    // PUT: api/producto/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateProductoCommand command)
    {
        if (id != command.Id)
            return BadRequest("El ID de la ruta no coincide con el del cuerpo.");

        var producto = await _mediator.Send(command);
        return producto is null ? NotFound() : Ok(producto);
    }

    // DELETE: api/producto/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var eliminado = await _mediator.Send(new DeleteProductoCommand(id));
        return eliminado ? NoContent() : NotFound();
    }
}

