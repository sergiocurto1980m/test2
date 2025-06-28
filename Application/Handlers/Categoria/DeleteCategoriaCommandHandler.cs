using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands;
using Infrastructure.Data;
using MediatR;

namespace Application.Handlers.Categoria;
public class DeleteCategoriaCommandHandler : IRequestHandler<DeleteCategoriaCommand,Unit>
{
    private readonly AppDbContext _context;

    public DeleteCategoriaCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteCategoriaCommand request, CancellationToken cancellationToken)
    {
        var categoria = await _context.Categorias.FindAsync(request.Id);
        if (categoria == null)
            throw new Exception("Categoría no encontrada");

        _context.Categorias.Remove(categoria);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}