using Fiorello.API.Middelewares;
using Fiorello.Application.Abstraction.Repository;
using Fiorello.Application.Abstraction.Services;
using Fiorello.Application.Validators.CategoryValidators;
using Fiorello.Domain.Entities;
using Fiorello.Persistance;
using Fiorello.Persistance.Contexts;
using Fiorello.Persistance.Implementations.Repositories;
using Fiorello.Persistance.Implementations.Services;
using Fiorello.Persistance.MapperProfiles;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddPersistenceServices();
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<AppDbContext>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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