using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeData.Commons.Entity
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string Gender {  get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
