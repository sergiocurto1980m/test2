using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;

namespace Application.Queries;

public record GetProductoByIdQuery(int Id) : IRequest<Producto?>;

public record GetAllProductosQuery() : IRequest<IEnumerable<Producto>>;