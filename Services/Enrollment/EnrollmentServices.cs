using AutoMapper;
using HuynhTanLoc_K2023_THIGK.Data;
using HuynhTanLoc_K2023_THIGK.Dtos.Enrollment;
using HuynhTanLoc_K2023_THIGK.Entity;
using Microsoft.EntityFrameworkCore;

namespace HuynhTanLoc_K2023_THIGK.Services.Enrollment
{
    public class EnrollmentServices : IEnrollmentServices
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public EnrollmentServices(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Create(EnrollmentCreateRequest request)
        {
            var enroll = _mapper.Map<EnrollmentEntity>(request);
            enroll.Confirmed = false;
            enroll.EnrollCode = Guid.NewGuid().ToString().Substring(0,6);
            _context.AddAsync(enroll);
            await _context.SaveChangesAsync();
            return enroll.Id;
        }

        public async Task<bool> Delete(Guid id)
        {
            var enroll = await _context.Enrollments.FirstOrDefaultAsync(x => x.Id == id);
            if (enroll == null)
            {
                throw new Exception("Ghi danh khong ton tai");
            }
            _context.Remove(enroll);
            await _context.SaveChangesAsync();
            return true;
        }

       

        public async Task<List<EnrollmentEntity>> GetAll(Guid id)
        {
            return await _context.Enrollments.Where(x => x.CourseId == id).ToListAsync();       
        }

        public async Task<EnrollmentEntity> Update(Guid id)
        {
            var enroll = await _context.Enrollments.FirstOrDefaultAsync(x => x.Id == id);
            if(enroll == null)
            {
                throw new Exception("Khong ton tai ban ghi danh");
            }
            enroll.Confirmed = true;
            _context.Update(enroll);
            await _context.SaveChangesAsync();
            return enroll;
        }
    }
}
