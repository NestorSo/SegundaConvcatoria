using Microsoft.EntityFrameworkCore;
using SegundaConvcatoria;
using SegundaConvcatoria.Data;
using SegundaConvcatoria.Models;
using SegundaConvcatoria.RepostoryF;
using SegundaConvcatoria.RepostoryF.IRepositoryF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<CineContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
});
builder.Services.AddScoped<IPeliculasRepository, PeliculasRepository>();
builder.Services.AddScoped<IGenerosRepositoy, GenerosRepository>();

builder.Services.AddAutoMapper(typeof(MappingConfig));

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
