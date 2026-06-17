using HRMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Domain.Entities 
{
    public class Designation : BasicEntity
    {
        [Key]
        public int DesignationId { get; set; }

        public string DesignationCode { get; set; } = string.Empty;

        public string DesignationName { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}
