using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Queries;
using Domain.DTO;
using Infrastructure.Data;
using MediatR;

namespace Application.Handlers.Categoria;
public class GetCategoriaByIdQueryHandler : IRequestHandler<GetCategoriaByIdQuery, CategoriaDto>
{
    private readonly AppDbContext _context;

    public GetCategoriaByIdQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<CategoriaDto> Handle(GetCategoriaByIdQuery request, CancellationToken cancellationToken)
    {
        var categoria = await _context.Categorias.FindAsync(request.Id);

        if (categoria == null)
            throw new Exception("Categoría no encontrada");

        return new CategoriaDto
        {
            Id = categoria.Id,
            Nombre = categoria.Nombre
        };
    }
}