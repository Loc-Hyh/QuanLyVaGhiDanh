using System.ComponentModel.DataAnnotations;

namespace HuynhTanLoc_K2023_THIGK.Dtos.Course
{
    public class CourseCreateRequest
    { 
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
    }
}
