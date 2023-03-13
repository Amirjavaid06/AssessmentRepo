using Domain.Aggregates.TaskAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Task.Queries
{
    public class GetAllTasksQuery : IRequest<IEnumerable<Tasks>>
    {
    }
}
