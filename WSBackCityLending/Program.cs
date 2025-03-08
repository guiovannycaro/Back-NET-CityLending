using WSBackCityLending.aplicacion.dao;
using WSBackCityLending.infraestructura.interfases;
using WSBackCityLending.infraestructura.util;


var builder = WebApplication.CreateBuilder(args);


//Add Cors politics

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // Permitir Angular
                  .AllowAnyMethod() // Permitir cualquier método HTTP (GET, POST, etc.)
                  .AllowAnyHeader() // Permitir cualquier encabezado
                  .AllowCredentials(); // Permitir credenciales (si es necesario)
        });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<executeQueryBD>();






builder.Services.AddScoped<IAreasInter, AreasDaoImpl>();
builder.Services.AddScoped<AreasDaoImpl>();


builder.Services.AddScoped<ICompanyAreaInter, CompanyAreaDaoImpl>();
builder.Services.AddScoped<CompanyAreaDaoImpl>();

builder.Services.AddScoped<ICompanyLocationInter, CompanyLocationDaoImpl>();
builder.Services.AddScoped<CompanyLocationDaoImpl>();


builder.Services.AddScoped<ISheduleUserInter, ScheduleuserDaoImpl>();
builder.Services.AddScoped<ScheduleuserDaoImpl>();

builder.Services.AddScoped<IProfileInter, ProfileDaoImpl>();
builder.Services.AddScoped<ProfileDaoImpl>();

builder.Services.AddScoped<IServicioSeguridadInter, ServicioSeguridadDaoImpl>();
builder.Services.AddScoped<ServicioSeguridadDaoImpl>();

builder.Services.AddScoped<IUsersInter, UsersDaoImpl>();
builder.Services.AddScoped<UsersDaoImpl>();

var app = builder.Build();

app.UseCors("AllowAngular");

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
