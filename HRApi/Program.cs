using EntityFrameworkCore.UseRowNumberForPaging;
using HR.Core;
using HR.Core.MiddleWare;
using HR.Infrustructure;
using HR.Infrustructure.Context;
using HR.Service;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//connection Sql 
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbcontext"),
     o => o.UseRowNumberForPaging());
});


#region Dependency injections

builder.Services.AddInfrastructureDependencies().
    AddServiceDependencies()
    .AddCoreDependencies();

#endregion

#region Localization
builder.Services.AddControllersWithViews();
builder.Services.AddLocalization(opt =>
{
    opt.ResourcesPath = "";
});

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    List<CultureInfo> supportedCultures = new List<CultureInfo>
    {
            new CultureInfo("en-US"),
            new CultureInfo("de-DE"),
            new CultureInfo("fr-FR"),
            new CultureInfo("ar-EG")
    };

    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

#endregion


//#region AllowCORS
//var CORS = "_cors";
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: CORS,
//                      policy =>
//                      {
//                          policy.AllowAnyHeader();
//                          policy.AllowAnyMethod();
//                          policy.AllowAnyOrigin();
//                      });
//});

//#endregion



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
//app.UseCors(CORS);
app.UseAuthorization();

app.MapControllers();

app.Run();
