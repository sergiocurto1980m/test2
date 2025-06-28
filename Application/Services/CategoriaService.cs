using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands;
using Application.Interfaces;
using Application.Queries;
using Domain.DTO;
using MediatR;

namespace Application.Services;
public class CategoriaService : ICategoriaService
{
    private readonly IMediator _mediator;

    public CategoriaService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<int> CrearAsync(string nombre)
    {
        return await _mediator.Send(new CreateCategoriaCommand { Nombre = nombre });
    }

    public async Task ActualizarAsync(int id, string nombre)
    {
        await _mediator.Send(new UpdateCategoriaCommand { Id = id, Nombre = nombre });
    }

    public async Task EliminarAsync(int id)
    {
        await _mediator.Send(new DeleteCategoriaCommand { Id = id });
    }

    public async Task<CategoriaDto> ObtenerPorIdAsync(int id)
    {
        return await _mediator.Send(new GetCategoriaByIdQuery { Id = id });
    }

    public async Task<List<CategoriaDto>> ObtenerTodasAsync()
    {
        return await _mediator.Send(new GetAllCategoriasQuery());
    }
}
