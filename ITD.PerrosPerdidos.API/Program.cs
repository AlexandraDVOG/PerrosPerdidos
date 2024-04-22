using Microsoft.OpenApi.Models;




var builder = WebApplication.CreateBuilder(args);


var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");


if (string.IsNullOrEmpty(environment))
{
    throw new ArgumentException("La variable de entorno ASPNETCORE_ENVIRONMENT no está configurada.");
}


builder.Configuration.AddJsonFile($"appsettings.{environment}.json");


builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(options =>
{

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Simulación de Perros Perdidos",
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
        Description = "Requiere autenticación básica.",
        In = ParameterLocation.Header
    });
});


builder.Services.AddInfrestucture(builder.Configuration);




builder.Services.AddApl




builder.Services.AddCors();


var app = builder.Build();
