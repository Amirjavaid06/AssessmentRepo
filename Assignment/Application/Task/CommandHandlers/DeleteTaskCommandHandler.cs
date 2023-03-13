using Application.Task.Commands;
using DAL;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Task.CommandHandlers
{
    internal class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
    {

        private readonly DataContext _context;
        public DeleteTaskCommandHandler(DataContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _context.Tasks.FindAsync(request.Id);
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return new Unit();
        }
    }
}
