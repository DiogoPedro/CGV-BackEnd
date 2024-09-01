using CGV_BackEnd.Context;
using CGV_BackEnd.Controllers;
using CGV_BackEnd.Models.Interface;
using CGV_BackEnd.Services;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LawyerContext>(options =>
	options.UseMySql(builder.Configuration.GetConnectionString("MySQL_WebAPI"), new MySqlServerVersion(new Version(8, 0, 36))));

builder.Services.AddDbContext<LawyerCommandContext>(options =>
	options.UseMySql(builder.Configuration.GetConnectionString("MySQL_WebAPI"), new MySqlServerVersion(new Version(8, 0, 36))));

builder.Services.AddDbContext<LawyerQueryContext>(options =>
	options.UseMySql(builder.Configuration.GetConnectionString("MySQL_WebAPI"), new MySqlServerVersion(new Version(8, 0, 36))));

// Add services to the container.
builder.Services.AddScoped<ILawyerCommandContext, LawyerCommandContext>();
builder.Services.AddScoped<ILawyerQueryContext, LawyerQueryContext>();
builder.Services.AddScoped<LawyerService>();
builder.Services.AddControllers();
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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
};

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
