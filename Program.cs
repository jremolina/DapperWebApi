

using DapperWebApi;
using DapperWebApi.Servicios;

var builder = WebApplication.CreateBuilder(args);
// IConfiguration Configuration;

// Add services to the container.
var config = builder.Configuration;
var cadenaConexion = new ConexionBaseDatos(config.GetConnectionString("Conexion"));
builder.Services.AddSingleton(cadenaConexion);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddSingleton<IServicioEmpleado, ServicioEmpleado>();
builder.Services.AddSingleton<IServicioEmpleadosql, ServicioEmpleadosql>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
