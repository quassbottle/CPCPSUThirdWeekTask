using Microsoft.EntityFrameworkCore;
using Week3.Domain.Entities;
using Week3.Domain.Interfaces;
using Week3.Migration;
using Week3.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddDbContext<ProductContext>(options =>
// {
//     options.UseSqlite(builder.Configuration.GetConnectionString("Default"));
// });

builder.Services.AddDbContext<ProductContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

using (var context = new ProductContext())
{
    context.Database.EnsureCreated();
}

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