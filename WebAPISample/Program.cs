

using Microsoft.EntityFrameworkCore;
using WebAPISample.Data;
using WebAPISample.Infrastructure;
using WebAPISample.Interface.Example.Repository;
using WebAPISample.Interface.Example.Service;
using WebAPISample.Interface.Sample.Repository;
using WebAPISample.Interface.Sample.Service;
using WebAPISample.Respon.Example.Repository;
using WebAPISample.Respon.Example.Service;
using WebAPISample.Respon.Sample.Reponsitory;
using WebAPISample.Respon.Sample.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//kết nối db
builder.Services.AddDbContext<SampleDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Services Sample
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ISampleRepository, SampleRepository>();
builder.Services.AddScoped<ISampleService, SampleService>();
// Services Example
builder.Services.AddScoped<IExampleRepository, ExampleRepository>();
builder.Services.AddScoped<IExampleService, ExampleService>();

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
