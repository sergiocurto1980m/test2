using MediatR;
using Application.Queries;
using Infrastructure.Data;
using Application.Interfaces;

namespace Application.Handlers.Producto;

public class GetProductoByIdHandler : IRequestHandler<GetProductoByIdQuery, Domain.Entities.Producto?>
{
    private readonly IProductoService _productoService;

    public GetProductoByIdHandler(IProductoService productoService)
    {
        _productoService = productoService;
    }

    public Task<Domain.Entities.Producto?> Handle(GetProductoByIdQuery request, CancellationToken cancellationToken)
    {
        return _productoService.GetByIdAsync(request.Id, cancellationToken);
    }
}