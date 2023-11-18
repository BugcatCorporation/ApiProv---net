using ApiProv.DbContexts;
using ApiProv.Helpers;
using ApiProv.Repositories;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
// DbContext
builder.Services.AddDbContext<ProvDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("connection")));

builder.Services.AddScoped<IProveedorRepository, ProveedorRepository>();

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
