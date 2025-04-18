using AutoMapper;
using Azure.Core;
using HuynhTanLoc_K2023_THIGK.Data;
using HuynhTanLoc_K2023_THIGK.Dtos.Course;
using HuynhTanLoc_K2023_THIGK.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace HuynhTanLoc_K2023_THIGK.Services.Course
{
    public class CourseServices : ICourseServices
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public CourseServices(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<Guid> Create(CourseCreateRequest request)
        {
            var courseExits= await _appDbContext.Courses.FirstOrDefaultAsync(c => c.Title==request.Title);
            if (courseExits!=null)
            {
                throw new Exception("Khóa học đã tồn tại");
            }
            var course = _mapper.Map<CourseEntity>(request);
            course.StartDate= DateTime.Now;
            await _appDbContext.AddRangeAsync(course);
            _appDbContext.SaveChanges();
            return course.Id;
        }

        public async Task<bool> Delete(Guid id)
        {
            var courseExits= await _appDbContext.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if (courseExits==null)
            {
                throw new Exception("Không tồn tại khóa học");
            }
            _appDbContext.Remove(courseExits);
            _appDbContext.SaveChanges();
            return true;
        }

        public async Task<List<CourseEntity>> GetAll()
        {
            var result = await _appDbContext.Courses.ToListAsync();
            if (result.Count == 0)
            {
                throw new Exception("Không có dữ liệu");
            }
            return result;
        }
        public async  Task<CourseEntity> GetById(Guid Id)
        {
            var courseExits = await _appDbContext.Courses.FirstOrDefaultAsync(c => c.Id == Id);
            if (courseExits==null)
            {
                throw new Exception("Không tồn tại  khóa học");
            }
            return courseExits;
        }

        public async Task<CourseEntity> Update(CourseUpdateRequest request)
        {
            var courseExits = await _appDbContext.Courses.FirstOrDefaultAsync(c => c.Id == request.Id);
            if (courseExits == null)
            {
                throw new Exception("Khóa học không đã tồn tại");
            }
            _mapper.Map(request,courseExits);
            _appDbContext.Update(courseExits);
            await _appDbContext.SaveChangesAsync();
            return courseExits;
        }
    }
}
