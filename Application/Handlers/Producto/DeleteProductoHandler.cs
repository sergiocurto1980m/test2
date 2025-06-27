using MediatR;
using Application.Commands;
using Infrastructure.Data;
using Application.Interfaces;
using TuSolucion.Application.Services;

namespace Application.Handlers.Producto;

public class DeleteProductoHandler : IRequestHandler<DeleteProductoCommand, bool>
{
    private readonly IProductoService _productoService;

    public DeleteProductoHandler(IProductoService productoService)
    {
        _productoService = productoService;
    }

    public Task<bool> Handle(DeleteProductoCommand request, CancellationToken cancellationToken)
    {
        return _productoService.DeleteAsync(request.Id, cancellationToken);
    }
}
