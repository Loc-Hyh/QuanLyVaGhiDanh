using System.ComponentModel.DataAnnotations;

namespace HuynhTanLoc_K2023_THIGK.Dtos.Course
{
    public class CourseUpdateRequest
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
