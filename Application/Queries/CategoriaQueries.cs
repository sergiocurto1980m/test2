using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.DTO;
using MediatR;

namespace Application.Queries;
// Consulta para obtener todas las categorías
public record GetAllCategoriasQuery() : IRequest<List<CategoriaDto>>;

// Consulta para obtener una categoría por Id
public class GetCategoriaByIdQuery : IRequest<CategoriaDto>
{
    public int Id { get; set; }
}