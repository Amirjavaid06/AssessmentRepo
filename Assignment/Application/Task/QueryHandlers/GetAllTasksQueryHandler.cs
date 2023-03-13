using Application.Task.Queries;
using DAL;
using Domain.Aggregates.TaskAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Task.QueryHandlers
{
    public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, IEnumerable<Tasks>>
    {
        private readonly DataContext _context;
        public GetAllTasksQueryHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tasks>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var task = await _context.Tasks.ToListAsync();
            if (task is null)
            {
                return new List<Tasks>();
            }
            return task;
        }
    }
}
