using HRMS.Domain.Common;
using HRMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Domain.Entity
{
     public class Employee : BasicEntity
     {
        [Key]
        public int EmployeeId { get; set; }
        public string Employeename { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateOnly DOB { get; set; }
        public int DesignationId { get; set; }

        public virtual Designation Designation { get; set; }

    }
}
