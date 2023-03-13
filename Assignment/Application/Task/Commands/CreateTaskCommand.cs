using Domain.Aggregates.TaskAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Task.Commands
{
    public class CreateTaskCommand:IRequest<Tasks>
    {       
        public string Title { get;  set; }
        public string Description { get;  set; }
        public DateTime? DueDate { get;  set; }
    }
}
