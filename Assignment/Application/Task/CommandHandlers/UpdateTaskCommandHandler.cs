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
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, Tasks>
    {
        private readonly DataContext _context;
        public UpdateTaskCommandHandler(DataContext context)
        {
            _context = context;
        }
        public async Task<Tasks> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task=await _context.Tasks.FindAsync(request.Id);

            task.UpdateTask(request.Title, request.Description, request.DueDate);
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
            return task;

        }
    }
}
