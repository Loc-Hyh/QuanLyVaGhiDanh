using AutoMapper;
using HuynhTanLoc_K2023_THIGK.Dtos.Course;
using HuynhTanLoc_K2023_THIGK.Dtos.Enrollment;
using HuynhTanLoc_K2023_THIGK.Entity;

namespace HuynhTanLoc_K2023_THIGK.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap< CourseCreateRequest, CourseEntity>();
            CreateMap< CourseUpdateRequest, CourseEntity>()
                .ForMember(dest => dest.StartDate, o => o.Ignore());

            CreateMap<EnrollmentCreateRequest, EnrollmentEntity>()
                .ForMember(dest => dest.EnrollCode, o=>o.Ignore());

            CreateMap<EnrollmentEntity, EnrollmentDto>();
        }
    }
}
