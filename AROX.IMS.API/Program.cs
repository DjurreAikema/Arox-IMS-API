using AROX.IMS.API.Services;
using DBTools;
using GeneralTools.AspNetCore.MinimalApi;
using IMS.EF.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

// --- Initialize builder
var builder = WebApplication.CreateBuilder(args);

// --- CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("BasePolicy",
        b =>
        {
            b.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

// TODO: Idk what this do?
builder.Services.AddControllers();

// --- Database
builder.Services.AddAroxDb(opt => opt.ConnectionString =
    builder.Configuration.GetConnectionString("IMS") ??
    throw new NullReferenceException("Connection string not set"));

builder.Services.AddDbContextFactory<AROX_IMSContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("IMS"),
        sqlOpt => sqlOpt.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));

// --- Services
builder.Services.AddSingleton<ApplicationService>();
builder.Services.AddSingleton<CustomerService>();
builder.Services.AddSingleton<FieldTypeService>();
builder.Services.AddSingleton<InputOptionService>();
builder.Services.AddSingleton<ToolInputService>();
builder.Services.AddSingleton<ToolOutputService>();
builder.Services.AddSingleton<ToolService>();

// --- API Endpoints
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo {Title = "AROX-IMS", Version = "v1"});
    c.CustomSchemaIds(type => type.FullName);
});

// --- App
var app = builder.Build();
app.UseCors("BasePolicy"); // Use CORS policy
app.UseSwagger(); // Use Swagger for API documentation
app.UseSwaggerUI(); // Use Swagger UI for API documentation
app.MapControllers(); // TODO
app.MapEndpoints(); // TODO
app.Run();