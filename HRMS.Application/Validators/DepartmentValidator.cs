using FluentValidation;
using HRMS.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Validators
{
    public class DepartmentValidator : AbstractValidator<CreateDepartmentDto>
    {
        public DepartmentValidator()
        {
            RuleFor(x => x.DepartmentName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.DepartmentCode)
                .NotEmpty()
                .MaximumLength(20);
        }
    }
}
