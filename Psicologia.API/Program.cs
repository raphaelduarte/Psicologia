using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Psicologia.Domain.Commands.Contracts;
using Psicologia.Domain.Commands.Endereco.Bairro;
using Psicologia.Domain.Commands.Endereco.BairroCidade;
using Psicologia.Domain.Handlers.Contracts;
using Psicologia.Domain.Handlers.Endereco;
using Psicologia.Domain.Repositories.Endereco;
using Psicologia.Domain.Validator.Endereco.Cidade;
using Psicologia.Domain.Validator.Endereco.Estado;
using Psicologia.Domain.Validator.Endereco.Logradouro;
using Psicologia.Domain.Validator.Endereco.NumeroEndereco;
using Psicologia.Domain.Validator.Endereco.Pais;
using Psicologia.Infrastructure.Contexts;
using Psicologia.Infrastructure.Repositories.Endereco;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));
// builder.Services.AddDbContext<DataContext>(opt => 
//     opt.UseSqlServer("Data Source=desktop-i4tk8nf\\sqlexpress;Initial Catalog=HahnDb;Integrated Security=True;Trusted_Connection=True;Encrypt=False"));

builder.Services.AddControllers()
    .AddFluentValidation(config =>
    {
        config.RegisterValidatorsFromAssemblyContaining<CreateLogradouroValidator>();
        config.RegisterValidatorsFromAssemblyContaining<UpdateLogradouroValidator>();
        config.RegisterValidatorsFromAssemblyContaining<RemoveLogradouroValidator>();
        config.RegisterValidatorsFromAssemblyContaining<RemoveNumeroEnderecoValidator>();
        config.RegisterValidatorsFromAssemblyContaining<UpdateNumeroEnderecoValidator>();
        config.RegisterValidatorsFromAssemblyContaining<CreateNumeroEnderecoValidator>();
        config.RegisterValidatorsFromAssemblyContaining<RemoveBairroValidator>();
        config.RegisterValidatorsFromAssemblyContaining<UpdateBairroValidator>();
        config.RegisterValidatorsFromAssemblyContaining<CreateBairroValidator>();
        config.RegisterValidatorsFromAssemblyContaining<RemoveCidadeValidator>();
        config.RegisterValidatorsFromAssemblyContaining<UpdateCidadeValidator>();
        config.RegisterValidatorsFromAssemblyContaining<CreateCidadeValidator>();
        config.RegisterValidatorsFromAssemblyContaining<RemoveEstadoValidator>();
        config.RegisterValidatorsFromAssemblyContaining<UpdateEstadoValidator>();
        config.RegisterValidatorsFromAssemblyContaining<CreateEstadoValidator>();
        config.RegisterValidatorsFromAssemblyContaining<RemovePaisValidator>();
        config.RegisterValidatorsFromAssemblyContaining<UpdatePaisValidator>();
        config.RegisterValidatorsFromAssemblyContaining<CreatePaisValidator>();
    });

builder.Services.AddTransient<ILogradouroRepository, LogradouroRepository>();
builder.Services.AddTransient<LogradouroHandler, LogradouroHandler>();

builder.Services.AddTransient<INumeroEnderecoRepository, NumeroEnderecoRepository>();
builder.Services.AddTransient<NumeroEnderecoHandler, NumeroEnderecoHandler>();

builder.Services.AddTransient<IBairroRepository, BairroRepository>();
builder.Services.AddTransient<BairroHandler, BairroHandler>();

builder.Services.AddTransient<ICidadeRepository, CidadeRepository>();
builder.Services.AddTransient<CidadeHandler, CidadeHandler>();

builder.Services.AddTransient<IBairroCidadeRepository, BairroCidadeRepository>();
builder.Services.AddTransient<BairroCidadeHandler, BairroCidadeHandler>();

builder.Services.AddTransient<IEstadoRepository, EstadoRepository>();
builder.Services.AddTransient<EstadoHandler, EstadoHandler>();

builder.Services.AddTransient<ICidadeEstadoRepository, CidadeEstadoRepository>();
builder.Services.AddTransient<CidadeEstadoHandler, CidadeEstadoHandler>();

builder.Services.AddTransient<IPaisRepository, PaisRepository>();
builder.Services.AddTransient<PaisHandler, PaisHandler>();

builder.Services.AddTransient<IEnderecoRepository, EnderecoRepository>();




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();