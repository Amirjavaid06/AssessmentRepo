using Application.Task.Commands;
using DAL;
using Domain.Aggregates.TaskAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Task.CommandHandlers
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Tasks>
    {
        private readonly DataContext _context;
        public CreateTaskCommandHandler(DataContext context)
        {
            _context = context;
        }
        public async Task<Tasks> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task=Tasks.CreateNewTask(request.Title, request.Description, request.DueDate);
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }
    }
}
