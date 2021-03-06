using GerenciadorDeContas.ContasBancarias.Data;
using GerenciadorDeContas.ContasBancarias.Repositories.Implementations;
using GerenciadorDeContas.ContasBancarias.Repositories.IRepositories;
using GerenciadorDeContas.ContasBancarias.Services.Implementations;
using GerenciadorDeContas.ContasBancarias.Services.IServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<AppDbContext>(opts =>
{
    opts.UseLazyLoadingProxies().UseMySql(builder.Configuration.GetConnectionString("Banco"), new MySqlServerVersion(new Version(8, 0, 26)));
});
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IEnderecoService, EnderecoService>();
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
builder.Services.AddScoped<IAgenciaService, AgenciaService>();
builder.Services.AddScoped<IAgenciaRepository, AgenciaRepository>();
builder.Services.AddScoped<IContaService, ContaService>();
builder.Services.AddScoped<IContaRepository, ContaRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
