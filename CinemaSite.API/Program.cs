using CinemaSite.BusinessLogic;
using CinemaSite.BusinessLogic.Extensions;
using CinemaSite.BusinessLogic.Intefaces.Services;
using CinemaSite.BusinessLogic.Services;
using CinemaSite.Domain;
using CinemaSite.Domain.Interfaces;
using CinemaSite.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<CinemaDbContext>(options => 
{
    options.UseSqlite(builder.Configuration.GetConnectionString(nameof(CinemaDbContext)));
});

builder.Services.AddScoped<IUserRepository, UsersRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddAuth(builder.Configuration);

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
