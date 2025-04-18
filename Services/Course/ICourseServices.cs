
using HuynhTanLoc_K2023_THIGK.Data;
using HuynhTanLoc_K2023_THIGK.Dtos.Course;
using HuynhTanLoc_K2023_THIGK.Entity;
using Microsoft.EntityFrameworkCore;

namespace HuynhTanLoc_K2023_THIGK.Services.Course
{
    public interface ICourseServices
    {
        Task<Guid> Create(CourseCreateRequest request);
        Task<CourseEntity> Update(CourseUpdateRequest request);
        Task<List<CourseEntity>> GetAll();
        Task<CourseEntity> GetById(Guid id);
        Task<bool> Delete(Guid id);
    }
}
