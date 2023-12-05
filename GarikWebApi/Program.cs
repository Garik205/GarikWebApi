using DataBase;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationContext>(opts => opts.UseSqlite("Data Source=DBuser.db"), ServiceLifetime.Transient); // ����� ���������� ��� ����������� ������ ������ ApplicationContext � ���������� IOC

builder.Services.AddAutoMapper(typeof(Program).Assembly); // ��������� AutoMapper � DI ���������

//builder.Services.AddScoped
//builder.Services.AddTransient
//builder.Services.AddSingleton

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
