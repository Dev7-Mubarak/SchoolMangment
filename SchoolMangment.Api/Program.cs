using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SchoolMangment.Core;
using SchoolMangment.Core.Middleware;
using SchoolMangment.Infastructure;
using SchoolMangment.Infastructure.Data;
using SchoolMangment.Services;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

#region Add Dependency Injection
builder.Services.AddInfrastructureDependencies()
                .AddServicesDependencies()
                .AddCoreDependencies()
                .AddServiceRegistration(builder.Configuration);
#endregion

#region Localization
builder.Services.AddControllersWithViews();
builder.Services.AddLocalization(opt =>
{
    opt.ResourcesPath = "Resurces";
});

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    List<CultureInfo> supportedCultures = new()
    {
         new CultureInfo("en-US"),
         new CultureInfo("de-DE"),
         new CultureInfo("fr-FR"),
         new CultureInfo("ar-EG")
    };

    options.DefaultRequestCulture = new RequestCulture("ar-EG");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

#endregion

#region Cors
var Cors = "_CORS";
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: Cors,
        policy =>
        {
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
            policy.AllowAnyOrigin();
        }
    );
});
#endregion


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

#region Localization Middleware
var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(options.Value);
#endregion

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseCors(Cors);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
