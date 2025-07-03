using Mega_Troni_Auto.Data;
using Mega_Troni_Auto.Extensions;
using Mega_Troni_Auto.Helpers;
using Mega_Troni_Auto.Models;
using Mega_Troni_Auto.Services;
using Mega_Troni_Auto.Services.Interfaces;
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