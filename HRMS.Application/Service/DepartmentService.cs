using HRMS.Application.DTOs;
using HRMS.Application.Interface;
using HRMS.Domain.Entities;
using HRMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HrmsDbContext _context;
        public DepartmentService(HrmsDbContext context) { 
                _context = context;
        }

        public async Task<ApiResponse<List<DepartmentDto>>> GetDeaprtment(int? id)
        {
            var departments = await _context.Departments
                .FromSqlInterpolated($"EXEC usp.GetDeptByIdOrAll @ID = {id}")
                .ToListAsync();

            if (!departments.Any())
            {
                return new ApiResponse<List<DepartmentDto>>
                {
                    Success = false,
                    Message = "Department not found"
                };
            }

            return new ApiResponse<List<DepartmentDto>>
            {
                Success = true,
                Data = departments.Select(d => new DepartmentDto
                {
                    DeptId = d.DeptId,
                    DepartmentCode = d.DepartmentCode,
                    DepartmentName = d.DepartmentName
                }).ToList()
            };
        }
    }
}
