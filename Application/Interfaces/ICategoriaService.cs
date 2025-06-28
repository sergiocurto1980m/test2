using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO;

namespace Application.Interfaces;
public interface ICategoriaService
{
    Task<int> CrearAsync(string nombre);
    Task ActualizarAsync(int id, string nombre);
    Task EliminarAsync(int id);
    Task<CategoriaDto> ObtenerPorIdAsync(int id);
    Task<List<CategoriaDto>> ObtenerTodasAsync();
}