using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.Interfaces.IRespository;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Infrastructure.Data.Context;
using SchoolManagement.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// DbContext com a string de conexão do appsettings.json
builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add serviços básicos
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
builder.Services.AddScoped<IEscolaRepository, EscolaRepository>();
builder.Services.AddScoped<ITurmaRepository, TurmaRepository>();
builder.Services.AddScoped<IInscricaoRepository, InscricaoRepository>();



var app = builder.Build();

// Configuração do pipeline HTTP
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();