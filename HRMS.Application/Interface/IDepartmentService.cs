using HRMS.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Interface
{
    public interface IDepartmentService
    {
        Task<ApiResponse<List<DepartmentDto>>> GetDeaprtment(int? id);

        Task<ApiResponse<DepartmentDto>> CreateDept(DepartmentDto dept);
    }
}
