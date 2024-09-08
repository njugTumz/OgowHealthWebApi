using healthmanagementapi.DB;
using healthmanagementapi.Entities;
using healthmanagementapi.Repository;
using healthmanagementapi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Database Configurations
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<HealthDbContext>(options =>
    options
        .UseSqlServer(connectionString)
        .EnableSensitiveDataLogging()
        .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
    );

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireSuperAdmin", policy => policy.RequireRole("Super Admin"));
    options.AddPolicy("RequireAdmin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("RequireHealthWorker", policy => policy.RequireRole("Health Worker"));
});

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<HealthDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
// Add services to the container.
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IHealthFacilityService, HealthFacilityService>();
builder.Services.AddScoped<IHealthWorkerService, HealthWorkerService>();
builder.Services.AddScoped<IUserManagamentService, UserManagementService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IRoleService, RoleService>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    // Add other custom converters or settings if needed
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("https://jolly-stone-0bb101303.5.azurestaticapps.net/")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

var app = builder.Build();
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Health Management API V1");
        c.RoutePrefix = string.Empty; // To serve Swagger at the app's root (optional)
    });
}

app.UseCors("AllowSpecificOrigin");

//app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
