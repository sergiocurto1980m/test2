using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Audit
{
    public int Id { get; set; }
    public string TableName { get; set; } = string.Empty;
    public string KeyValues { get; set; } = string.Empty;   // JSON con la clave primaria
    public string? OldValues { get; set; }                   // JSON con los valores antes del cambio
    public string? NewValues { get; set; }                   // JSON con los valores después del cambio
    public string Action { get; set; } = string.Empty;       // Insert, Update, Delete
    public DateTime Date { get; set; }
    public string UserName { get; set; } = string.Empty;
}