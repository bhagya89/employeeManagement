using AutoMapper;
using EmployeeData.Commons.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeData.Commons.Dto
{
    public class ApplicationMapper : Profile
    {
      public ApplicationMapper()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            
        }


    }
}
