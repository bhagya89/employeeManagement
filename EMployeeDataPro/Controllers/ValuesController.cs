using EmployeeData.Commons.Dto;
using EmployeeData.Commons.Entity;
using EmployeeData.Services.BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace EmployeeDataPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ValuesController : ControllerBase
    {
        private readonly IEmployee employees;
       


        public ValuesController(IEmployee employees )
        {
           
            this.employees = employees;
        }
        
        
        [HttpGet]
        public async Task<List<Employee>> GetAll()
        {
            var Emp = await employees.ShowData();
            return Emp;

            
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await employees.DeleteEmployee(id);
            return Ok("deleted ");
        }

        [HttpPut("Update")]

        public async Task<IActionResult> Update( UpdateDto updateDto)
            
        {
            await employees.UpdateEmp(updateDto.Id , updateDto);
            return Ok("updated");
        }

        [HttpPost("create")]

        public async Task<IActionResult> Add(EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await employees.CreateEmp(employeeDto);
                return Ok("Added");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
}
