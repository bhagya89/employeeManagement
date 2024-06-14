using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace EmployeeData.Commons.Dto
{
    public class EmployeeDto
    {
        
        public string Name { get; set; }
        public decimal Salary { get; set; }
        [EnumDataType(typeof(Gender))]
        [Range(0,2, ErrorMessage = "invalid Gender")]
        public Gender gender { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
