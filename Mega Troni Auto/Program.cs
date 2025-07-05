using MegaTroniAuto.API.Data;
using MegaTroniAuto.API.Extensions;
using MegaTroniAuto.API.Helpers;
using MegaTroniAuto.API.Models;
using MegaTroniAuto.API.Services;
using MegaTroniAuto.API.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddAuthorization();
builder.Services.AddSwaggerWithJwt();

builder.Services.AddDbContext<MegaTronixDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<MegaTronixDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Seed roles
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await DbSeeder.SeedRolesAsync(services);
}

// Middleware pipeline
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