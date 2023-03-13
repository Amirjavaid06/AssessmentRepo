using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Aggregates.TaskAggregate
{
    public class Tasks
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime? DueDate { get; private set; }

        private Tasks()
        {

        }

        public static Tasks CreateNewTask(string title, string description, DateTime? dueDate)
        {
            return new Tasks
            {
                Description = description,
                Title = title,
                DueDate = dueDate,
            };
        }

        public void UpdateTask(string title, string description, DateTime? dueDate)
        {

            Description = description;
            Title = title;
            DueDate = dueDate;
        }
    }
}
