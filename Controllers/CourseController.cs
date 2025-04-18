using HuynhTanLoc_K2023_THIGK.Dtos.Course;
using HuynhTanLoc_K2023_THIGK.Services.Course;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HuynhTanLoc_K2023_THIGK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseServices _courseServices;
        public CourseController(ICourseServices courseServices)
        {
            _courseServices = courseServices;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _courseServices.GetAll();
            return Ok(result);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(CourseCreateRequest request)
        {
            var result = await _courseServices.Create(request);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _courseServices.GetById(id);
            return Ok(result);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _courseServices.Delete(id);
            return Ok(result);
        } 
        [HttpPut("update")]
        public async Task<IActionResult> Update(CourseUpdateRequest request)
        {
            var result = await _courseServices.Update(request);
            return Ok(result);
        }
       
    }
}
