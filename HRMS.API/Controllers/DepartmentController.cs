using Microsoft.AspNetCore.Mvc;

namespace HRMS.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        public DepartmentController() { }

        public async Task<IActionResult> GetADepartment()
        {

            return Ok();
        }
     }
}
