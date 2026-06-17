using Microsoft.AspNetCore.Mvc;

namespace HRMS.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
     //creating demo api
     [HttpGet]
     public IActionResult Get()
     {
        var response = new
        {
           Success = true,
           Message = "Dummy API Working",
           Data = new
           {
             EmployeeId = 1,
             EmployeeName = "John Smith",
             Department = "IT",
             Designation = "Software Engineer"
            }
         };

       return Ok(response);
      }

    }
}
