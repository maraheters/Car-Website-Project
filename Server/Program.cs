using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using DatabaseAccess;
using DatabaseAccess.Repositories;
using Server.Services;
using Server.Services.Interfaces;
using Server.Services.Mappers;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers();
builder.Services.AddScoped<CarsRepository>();
builder.Services.AddScoped<ICarsService, CarsService>();

builder.Services.AddDbContext<CarDbContext>(
    options => 
    {
        options.UseSqlite(configuration.GetConnectionString("Data Source"));
    }
);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

var app = builder.Build();
app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=GetAllCars}/{id?}");

app.Run();

//TODO: ADD TRANSMISSION AND DRIVETRAIN, ADD COUNTRY TO MANUFACTURER?
//TODO: RELOCATE PRICE TO POSTING
