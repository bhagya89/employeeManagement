using EmployeeData.Commons.Dto;
using EmployeeData.Commons.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeData.Services.BusinessLogic
{
    public interface IEmployee
    {
  
        Task<List<Employee>> ShowData();
        Task DeleteEmployee(int id);

        Task UpdateEmp(int id, UpdateDto updateDto);

        Task CreateEmp(EmployeeDto employeeDto);
    }
}
