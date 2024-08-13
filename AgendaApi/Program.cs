using AgendaApi.Repositories;
using AgendaApi.Repositories.Interfaces;
using AgendaApi.Services;
using AgendaApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using AgendaApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar o contexto do banco de dados
builder.Services.AddDbContext<AgendaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adicionar serviços ao container
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IContactService, ContactService>();

// Configuração adicional (opcional)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar o pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
