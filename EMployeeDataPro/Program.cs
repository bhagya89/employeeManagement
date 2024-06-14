using AutoMapper;
using EmployeeData.Commons.Dto;
using EmployeeData.DAL.Connection;
using EmployeeData.DAL.Repositiory;
using EmployeeData.Services.BusinessLogic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

internal class Programa
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        var provider = builder.Services.BuildServiceProvider();
        var config = provider.GetRequiredService<IConfiguration>();

        builder.Services.AddDbContext<EmployeeDBContext>(item => item.UseSqlServer(config.GetConnectionString("dbcs"), b => b.MigrationsAssembly("EmployeeDataPro")));
        //builder.Services.AddScoped<IRepositoryEmployee,EmpRepository>();
        //builder.Services.AddScoped<IRepositoryEmployee, EmpRepository>();
        builder.Services.AddScoped<IEmployee, Emp>();
        builder.Services.AddScoped<IRepositoryEmployee, EmpRepository>();

        builder.Services.AddAutoMapper(typeof(ApplicationMapper));





        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}