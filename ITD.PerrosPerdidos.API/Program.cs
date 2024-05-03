using ITD.PerrosPerdidos.Application;
using ITD.PerrosPerdidos.Infrestuctura;
using Microsoft.OpenApi.Models;




var builder = WebApplication.CreateBuilder(args);


var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");


if (string.IsNullOrEmpty(environment))
{
    throw new ArgumentException("La variable de entorno ASPNETCORE_ENVIRONMENT no esta configurada.");
}


builder.Configuration.AddJsonFile($"appsettings.{environment}.json");


builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
//builder.Services.addInfrestructure(builder.Configuration);
builder.Services.AddInfrestucture(builder.Configuration);
builder.Services.AddAplication(builder.Configuration);


builder.Services.AddSwaggerGen(options =>
{

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Simulacion de Perros Perdidos",
        Contact = new OpenApiContact
        {
            Name = "Dealexandra Valentina",
            Email = "20041390@itdurango.edu.mx"
        },
        Description = $"API en ambiente {environment}."
    });


    options.AddSecurityDefinition("Basic", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "basic",
        Description = "Requiere autenticacion basica.",
        In = ParameterLocation.Header
    });
});











builder.Services.AddCors();


var app = builder.Build();
