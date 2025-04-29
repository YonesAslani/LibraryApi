using FluentValidation.AspNetCore;
using LibraryValidation.ModelValidations;
using FluentValidation;
using LibraryDbManager.Context;
using Microsoft.EntityFrameworkCore;
using LibraryServices.IServices;
using LibraryServices.Services;
using LibraryValidation.ModelValidations.ReturnAndGetModelValidations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

#region Context
builder.Services.AddDbContext<MyContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
#endregion

#region Dependency Injection
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<IBookServices, BookServices>();
builder.Services.AddScoped<ICostumerServices, CostumerServices>();
builder.Services.AddScoped<IOrderServices, OrderServices>();
#endregion

#region FluentValidations
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<BookFluentValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<CategoryFluentValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<CostumerFluentValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<AdminFluentValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<BookGetModelFluentValidation>();
#endregion 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
