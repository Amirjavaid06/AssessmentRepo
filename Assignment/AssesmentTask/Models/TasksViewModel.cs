using System.ComponentModel.DataAnnotations;

namespace AssesmentTask.Models
{
    public class TasksViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? DueDate { get; set; }
    }
}
