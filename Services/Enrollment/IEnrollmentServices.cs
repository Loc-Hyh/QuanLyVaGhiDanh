using HuynhTanLoc_K2023_THIGK.Dtos.Course;
using HuynhTanLoc_K2023_THIGK.Dtos.Enrollment;
using HuynhTanLoc_K2023_THIGK.Entity;

namespace HuynhTanLoc_K2023_THIGK.Services.Enrollment
{
    public interface IEnrollmentServices
    {
        Task<Guid> Create(EnrollmentCreateRequest request);
        Task<EnrollmentEntity> Update(Guid id);
        Task<List<EnrollmentEntity>> GetAll(Guid id);
        //Task<List<EnrollmentDto>> Get(Guid id);
        Task<bool> Delete(Guid id);
    }
}
