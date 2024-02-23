using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<GestionPiscinasContext>();

builder.Services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajo>();

builder.Services.AddScoped<IClienteDAL, ClienteDALImpl>();
builder.Services.AddScoped<IClienteService, ClienteService>();

builder.Services.AddScoped<IEmpleadoDAL, EmpleadoDALImpl>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();

builder.Services.AddScoped<IReservaDAL, ReservaDALImpl>();
builder.Services.AddScoped<IReservaService, ReservaService>();

builder.Services.AddScoped<IPiscinaDAL, PiscinaDALImpl>();
builder.Services.AddScoped<IPiscinaService, PiscinaService>();

builder.Services.AddScoped<IPiscinaRepuestoDAL, PiscinaRepuestoDALImpl>();
builder.Services.AddScoped<IPiscinaRepuestoService, PiscinaRepuestoService>();

builder.Services.AddScoped<IPiscinaProductoDAL, PiscinaProductoDALImpl>();
builder.Services.AddScoped<IPiscinaProductoService, PiscinaProductoService>();

builder.Services.AddScoped<IServicioPiscinaDAL, ServicioPiscinaDALImpl>();
builder.Services.AddScoped<IPiscinaServicioService, PiscinaServicioService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
