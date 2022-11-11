using EmployeesAPI.Data;
using EmployeesAPI.IRepositories;
using EmployeesAPI.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<DataContext>(
    context => context.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<DataContext, DataContext>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddControllers();
builder.Services.AddCors(options => options.AddPolicy(name: "EmployeeAPP", policy =>
{
    policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("EmployeeAPP");

app.UseAuthorization();

app.MapControllers();

app.Run();
