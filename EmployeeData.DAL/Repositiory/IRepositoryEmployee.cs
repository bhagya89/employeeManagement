using EmployeeData.Commons.Dto;
using EmployeeData.Commons.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeData.DAL.Repositiory
{
    public interface IRepositoryEmployee
    {

        Task<List<Employee>> ShowData();
        Task DeleteEmployee(int id);

        Task UpdateEmp(int id, Employee employee);

        Task CreateEmp(Employee employee);
        Task<Employee> DoesEmployeeExist(string name);
        Task CheckGender(Gender gender);
    }
}
