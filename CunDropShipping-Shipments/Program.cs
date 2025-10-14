using CunDropShipping_Shipments.adapter.restful.v1.controller.Mapper;
using CunDropShipping_Shipments.infrastructure.DbContext;
using CunDropShipping_Shipments.application.Service;
using CunDropShipping_Shipments.domain;
using CunDropShipping_Shipments.infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// --- CONFIGURACIÓN DE SERVICIOS ---

// 1. Servicios básicos para la API y Swagger (sin cambios)
builder.Services.AddControllers(); // <-- ¡IMPORTANTE! Añade este servicio para que los controladores funcionen.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. Lee la cadena de conexión del archivo appsettings.json (sin cambios)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 3. Registra el AppDbContext en el contenedor de dependencias (sin cambios)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// --- REGISTRO DE TODAS LAS CAPAS PARA INYECCIÓN DE DEPENDENCIAS ---
// Aquí le decimos a la aplicación cómo construir cada pieza de nuestra arquitectura.

// Capa de Infraestructura
builder.Services.AddScoped<Repository>();
// CORREGIDO: El nombre de la clase de implementación es "InfrastructureMapper", no "InfrastructureMapperImpl"
builder.Services.AddScoped<IInfrastructureMapper, InfrastructureMapperImpl>();

// Capa de Dominio/Aplicación
// AÑADIDO: Registramos la interfaz del servicio con su implementación.
builder.Services.AddScoped<IShipmentsService, ShipmentServiceImp>();

// Capa de Adaptador
// AÑADIDO: Registramos la interfaz del mapper del adaptador con su implementación.
builder.Services.AddScoped<IAdapterMapper, AdapterMapper>();


var app = builder.Build();

// --- CONFIGURACIÓN DEL PIPELINE DE PETICIONES HTTP ---

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Le dice a la aplicación que use los controladores que definimos.
app.MapControllers();

app.Run();