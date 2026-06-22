using HRMS.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService) {
            _departmentService = departmentService;
        }

        [HttpPost("getdepartment")]
        public async Task<IActionResult> GetADepartment(int? id = 0)
        {
            var result = await _departmentService.GetDeaprtment(id);
            return Ok(result);
        }
     }
}
