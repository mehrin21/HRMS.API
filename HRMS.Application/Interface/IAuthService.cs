using HRMS.Application.DTOs;
using HRMS.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Interface
{
    public interface IAuthService
    {
       Task <ApiResponse<UserDto>> LoginAsync(LoginRequestDto data);
        
    }
}
