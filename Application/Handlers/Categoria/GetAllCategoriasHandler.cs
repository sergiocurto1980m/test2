using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Queries;
using Infrastructure.Data;
using MediatR;
using Domain.Entities;
using Domain.DTO;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Categoria;
public class GetAllCategoriasQueryHandler : IRequestHandler<GetAllCategoriasQuery, List<CategoriaDto>>
{
    private readonly AppDbContext _context;

    public GetAllCategoriasQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<CategoriaDto>> Handle(GetAllCategoriasQuery request, CancellationToken cancellationToken)
    {
        return await _context.Categorias
            .Select(c => new CategoriaDto
            {
                Id = c.Id,
                Nombre = c.Nombre
            })
            .ToListAsync(cancellationToken);
    }
}
