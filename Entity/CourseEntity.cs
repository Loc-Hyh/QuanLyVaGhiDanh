using System.ComponentModel.DataAnnotations;

namespace HuynhTanLoc_K2023_THIGK.Entity
{
    public class CourseEntity
    {
        public Guid Id { get; set; }
        [Required]
        public string Title {  get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set;}
        public List<EnrollmentEntity> Enrollments { get; set; }
    }   
}
