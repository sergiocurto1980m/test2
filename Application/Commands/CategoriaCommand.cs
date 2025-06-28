using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;

namespace Application.Commands;


// Comando para crear una categoría
public class CreateCategoriaCommand : IRequest<int>
{
    public string Nombre { get; set; }
}

public class UpdateCategoriaCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nombre { get; set; }
}

public class DeleteCategoriaCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
