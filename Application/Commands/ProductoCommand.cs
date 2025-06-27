using MediatR;
using Domain.Entities;

namespace Application.Commands;

public record CreateProductoCommand(string Nombre, int CategoriaId) : IRequest<Producto>;

public record UpdateProductoCommand(int Id, string Nombre, int CategoriaId) : IRequest<Producto>;

public record DeleteProductoCommand(int Id) : IRequest<bool>;
