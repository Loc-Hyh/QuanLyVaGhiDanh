using HuynhTanLoc_K2023_THIGK.Entity;

namespace HuynhTanLoc_K2023_THIGK.Dtos.Enrollment
{
    public class EnrollmentDto
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public string StudentName { get; set; }
        public string EnrollCode { get; set; }
        public bool Confirmed { get; set; } = false;
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
    }
}
