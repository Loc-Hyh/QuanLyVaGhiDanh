using HuynhTanLoc_K2023_THIGK.Dtos.Course;
using HuynhTanLoc_K2023_THIGK.Dtos.Enrollment;
using HuynhTanLoc_K2023_THIGK.Services.Enrollment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HuynhTanLoc_K2023_THIGK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentServices _enroll;
        public EnrollmentController(IEnrollmentServices enroll)
        {
            _enroll = enroll;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]Guid courseId)
        {
            var result = await _enroll.GetAll(courseId);
            return Ok(result);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(EnrollmentCreateRequest request)
        {
            var result = await _enroll.Create(request);
            return Ok(result);
        }
        [HttpPut("confirm")]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _enroll.Update(id);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _enroll.Delete(id);
            return Ok(result);
        }
    }
}
