using Microsoft.EntityFrameworkCore;
using TZ.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connect = builder.Configuration.GetConnectionString("PersonalConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connect));

builder.Services.AddControllers();

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
