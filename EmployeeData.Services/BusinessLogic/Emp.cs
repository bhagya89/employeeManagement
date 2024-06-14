
using EmployeeData.Commons.Entity;
using EmployeeData.DAL.Connection;
using EmployeeData.DAL.Repositiory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeData.Commons.Dto;

namespace EmployeeData.Services.BusinessLogic
{
    public class Emp : IEmployee
    {
        private readonly IRepositoryEmployee emp;
        private readonly IMapper mapper;

        public Emp(IRepositoryEmployee emp, IMapper mapper)
        {
            this.mapper = mapper;
            this.emp = emp;
        }


        public async Task<List<Employee>> ShowData()
        {

            return await emp.ShowData();
        }

        public async Task DeleteEmployee(int id)
        {
            await emp.DeleteEmployee(id);

        }

        public async Task UpdateEmp(int id, UpdateDto updateDto)
        {
            var employee = mapper.Map<Employee>(updateDto);

            await emp.UpdateEmp(id, employee);


        }


        public async Task CreateEmp(EmployeeDto employeeDto)
        {
            var employee = mapper.Map<Employee>(employeeDto);
            var existingEmployee = DoesEmployeeExist(employee);

            if (existingEmployee != null)
            {
                throw new Exception("Employee name already exists,enter new name");
            }


            await emp.CreateEmp(employee);
        }


        private async Task<Employee> DoesEmployeeExist(Employee employee)
        {
            return await emp.DoesEmployeeExist(employee.Name);
        }

    }
}

