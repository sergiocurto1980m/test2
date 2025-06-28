using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands;
using Infrastructure.Data;
using MediatR;

namespace Application.Handlers.Categoria;
public class CreateCategoriaCommandHandler : IRequestHandler<CreateCategoriaCommand, int>
{
    private readonly AppDbContext _context;

    public CreateCategoriaCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCategoriaCommand request, CancellationToken cancellationToken)
    {
        var categoria = new Domain.Entities.Categoria
        {
            Nombre = request.Nombre
        };

        _context.Categorias.Add(categoria);
        await _context.SaveChangesAsync(cancellationToken);

        return categoria.Id;
    }
}