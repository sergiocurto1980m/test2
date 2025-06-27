using MediatR;
using Application.Commands;
using Infrastructure.Data;
using Application.Interfaces;

namespace Application.Handlers.Producto;

public class UpdateProductoHandler : IRequestHandler<UpdateProductoCommand, Domain.Entities.Producto?>
{
    private readonly IProductoService _productoService;

    public UpdateProductoHandler(IProductoService productoService)
    {
        _productoService = productoService;
    }

    public Task<Domain.Entities.Producto?> Handle(UpdateProductoCommand request, CancellationToken cancellationToken)
    {
        return _productoService.UpdateAsync(request.Id, request.Nombre, request.CategoriaId, cancellationToken);
    }
}
