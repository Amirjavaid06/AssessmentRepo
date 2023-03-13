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
    public class GetTaskByIdQueryHandler:IRequestHandler<GetTaskByIdQuery,Tasks>
    {
        private readonly DataContext _context;
        public GetTaskByIdQueryHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Tasks> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
           var task =await _context.Tasks.FirstOrDefaultAsync(x => x.Id == request.Id);
            return task;
        }
    }
}
