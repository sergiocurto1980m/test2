
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.Json;

namespace Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Producto> Productos { get; set; } = null!;
    public DbSet<Categoria> Categorias { get; set; } = null!;
    public DbSet<Audit> Audits { get; set; } = null!;

    public string CurrentUser => _currentUser;

    private readonly string _currentUser = "System";

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {

    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var now = DateTime.UtcNow;

        // Obtener entradas de entidades que implementan AuditableEntity
        var auditableEntries = ChangeTracker.Entries()
            .Where(e => e.Entity is AuditableEntity &&
                       (e.State == EntityState.Added || e.State == EntityState.Modified))
            .ToList();

        foreach (var entry in auditableEntries)
        {
            var entity = (AuditableEntity)entry.Entity;
            if (entry.State == EntityState.Added)
            {
                entity.FechaCreacion = now;
                entity.UsuarioCreacion = CurrentUser;
            }
            else if (entry.State == EntityState.Modified)
            {
                entity.FechaModificacion = now;
                entity.UsuarioModificacion = CurrentUser;
            }
        }

        // Auditoría para cualquier entidad (incluyendo auditable y no)
        var auditEntries = new List<Audit>();

        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                continue;

            var auditEntry = new Audit
            {
                TableName = entry.Metadata.GetTableName() ?? string.Empty,
                Date = now,
                UserName = CurrentUser
            };

            // Obtener claves primarias
            var keyNames = entry.Metadata.FindPrimaryKey()?.Properties.Select(p => p.Name).ToList() ?? new List<string>();
            var keyValues = new Dictionary<string, object?>();
            foreach (var keyName in keyNames)
            {
                keyValues[keyName] = entry.Property(keyName).CurrentValue;
            }
            auditEntry.KeyValues = JsonSerializer.Serialize(keyValues);

            switch (entry.State)
            {
                case EntityState.Added:
                    auditEntry.Action = "Insert";
                    auditEntry.NewValues = JsonSerializer.Serialize(GetPropertyValues(entry.CurrentValues));
                    break;

                case EntityState.Deleted:
                    auditEntry.Action = "Delete";
                    auditEntry.OldValues = JsonSerializer.Serialize(GetPropertyValues(entry.OriginalValues));
                    break;

                case EntityState.Modified:
                    auditEntry.Action = "Update";
                    auditEntry.OldValues = JsonSerializer.Serialize(GetPropertyValues(entry.OriginalValues));
                    auditEntry.NewValues = JsonSerializer.Serialize(GetPropertyValues(entry.CurrentValues));
                    break;
            }

            auditEntries.Add(auditEntry);
        }

        Audits.AddRange(auditEntries);

        return await base.SaveChangesAsync(cancellationToken);
    }

    private Dictionary<string, object?> GetPropertyValues(PropertyValues values)
    {
        var dict = new Dictionary<string, object?>();
        foreach (var propertyName in values.Properties.Select(p => p.Name))
        {
            dict[propertyName] = values[propertyName];
        }
        return dict;
    }
}
