using EmployeeData.Commons.Entity;
using EmployeeData.DAL.Connection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeData.Commons.Dto;

namespace EmployeeData.DAL.Repositiory
{
    public class EmpRepository : IRepositoryEmployee
    {
        private readonly EmployeeDBContext employeeDB;
        
        public EmpRepository(EmployeeDBContext employeeDB)
        {
            this.employeeDB = employeeDB;
           
        }


        public async Task<List<Employee>> ShowData()
        {
            var empl = await employeeDB.Employees.ToListAsync();
            
            await employeeDB.SaveChangesAsync();
            return empl;
           
        }




        public async Task DeleteEmployee(int id)
        {
            var people = await employeeDB.Employees.FindAsync(id);
            employeeDB.Employees.Remove(people);
            await employeeDB.SaveChangesAsync();
        }

        public async Task UpdateEmp(int id, Employee employee)
        {
            var emp = await employeeDB.Employees.FindAsync(id);
            if (emp != null)
            {
                emp.Name = employee.Name;
                emp.Salary = employee.Salary;
                emp.Address = employee.Address;
                emp.Email = employee.Email;
                await employeeDB.SaveChangesAsync();
            }

        }

        public async Task CreateEmp(Employee employee)
        {

            await employeeDB.Employees.AddAsync(employee);

            await employeeDB.SaveChangesAsync();
        }
        public async Task<Employee> DoesEmployeeExist(string name) 
        {
            return await employeeDB.Employees.FirstOrDefaultAsync(e => e.Name == name);
        }

        public Task CheckGender(Gender gender)
        {
            throw new NotImplementedException();
        }
    }
}
