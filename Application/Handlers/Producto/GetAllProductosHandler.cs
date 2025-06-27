using MediatR;
using Microsoft.EntityFrameworkCore;
using Application.Queries;
using Infrastructure.Data;
using Application.Interfaces;

namespace Application.Handlers.Producto;

public class GetAllProductosHandler : IRequestHandler<GetAllProductosQuery, IEnumerable<Domain.Entities.Producto>>
{
    private readonly IProductoService _productoService;

    public GetAllProductosHandler(IProductoService productoService)
    {
        _productoService = productoService;
    }

    public Task<IEnumerable<Domain.Entities.Producto>> Handle(GetAllProductosQuery request, CancellationToken cancellationToken)
    {
        return _productoService.GetAllAsync(cancellationToken);
    }
}
