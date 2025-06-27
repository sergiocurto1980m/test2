using Domain.Entities;


namespace Application.Interfaces;

public interface IProductoService
{
    Task<Producto> CreateAsync(string nombre, int categoriaId, CancellationToken cancellationToken);
    Task<Producto?> UpdateAsync(int id, string nombre, int categoriaId, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    Task<Producto?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<IEnumerable<Producto>> GetAllAsync(CancellationToken cancellationToken);
}
