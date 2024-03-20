using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Students.Repositories.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<StudentContext>(options => { 
    options.UseSqlServer(builder.Configuration.GetConnectionString("StudentSQLConnection")); });


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


//builder.Services.AddScoped<IStudentsRepo, StudentsRepo>();

builder.Services.AddScoped<IStudentsRepo, SqlStudentsRepo>();

builder.Services.AddControllers().AddNewtonsoftJson(s =>
{ s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); });

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

app.UseAuthorization();

app.MapControllers();

app.Run();
