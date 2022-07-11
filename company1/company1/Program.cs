using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using company1.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<company1Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("company1Context") ?? throw new InvalidOperationException("Connection string 'company1Context' not found.")));

// Add services to the container.

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

app.UseAuthorization();
app.UseCors(Builder => Builder
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()); 


app.MapControllers();

app.Run();
