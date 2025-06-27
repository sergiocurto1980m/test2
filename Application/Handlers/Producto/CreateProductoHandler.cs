using MediatR;
using Application.Commands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Handlers.Producto;

public class CreateProductoHandler : IRequestHandler<CreateProductoCommand, Domain.Entities.Producto>
{
    private readonly IProductoService _productoService;

    public CreateProductoHandler(IProductoService productoService)
    {
        _productoService = productoService;
    }

    public Task<Domain.Entities.Producto> Handle(CreateProductoCommand request, CancellationToken cancellationToken)
    {
        return _productoService.CreateAsync(request.Nombre, request.CategoriaId, cancellationToken);
    }
}
