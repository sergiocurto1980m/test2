using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace TuSolucion.Application.Services;

public class ProductoService : IProductoService
{
    private readonly AppDbContext _context;

    public ProductoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Producto> CreateAsync(string nombre, int categoriaId, CancellationToken cancellationToken)
    {
        var producto = new Producto { Nombre = nombre, CategoriaId = categoriaId };
        _context.Productos.Add(producto);
        await _context.SaveChangesAsync(cancellationToken);
        return producto;
    }

    public async Task<Producto?> UpdateAsync(int id, string nombre, int categoriaId, CancellationToken cancellationToken)
    {
        var producto = await _context.Productos.FindAsync(new object[] { id }, cancellationToken);
        if (producto is null) return null;

        producto.Nombre = nombre;
        producto.CategoriaId = categoriaId;

        await _context.SaveChangesAsync(cancellationToken);
        return producto;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var producto = await _context.Productos.FindAsync(new object[] { id }, cancellationToken);
        if (producto is null) return false;

        _context.Productos.Remove(producto);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<Producto?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Productos.FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task<IEnumerable<Producto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Productos.ToListAsync(cancellationToken);
    }
}