using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Psicologia.Domain.Handlers.Endereco;
using Psicologia.Domain.Repositories.Endereco;
using Psicologia.Domain.Validator.Endereco.Logradouro;
using Psicologia.Domain.Validator.Endereco.NumeroEndereco;
using Psicologia.Infrastructure.Contexts;
using Psicologia.Infrastructure.Repositories.Endereco;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer("Data Source=desktop-i4tk8nf\\sqlexpress;Initial Catalog=HahnDb;Integrated Security=True;Trusted_Connection=True;Encrypt=False"));
builder.Services.AddControllers();
builder.Services.AddControllers()
    .AddFluentValidation(config =>
        config.RegisterValidatorsFromAssemblyContaining<CreateLogradouroValidator>())

    .AddFluentValidation(config =>
        config.RegisterValidatorsFromAssemblyContaining<UpdateLogradouroValidator>())

    .AddFluentValidation(config =>
        config.RegisterValidatorsFromAssemblyContaining<RemoveLogradouroValidator>())

    .AddFluentValidation(config =>
        config.RegisterValidatorsFromAssemblyContaining<RemoveNumeroEnderecoValidator>())

    .AddFluentValidation(config =>
        config.RegisterValidatorsFromAssemblyContaining<UpdateNumeroEnderecoValidator>())

    .AddFluentValidation(config =>
        config.RegisterValidatorsFromAssemblyContaining<CreateNumeroEnderecoValidator>())

    .AddFluentValidation(config =>
        config.RegisterValidatorsFromAssemblyContaining<RemoveBairroValidator>())
    
    .AddFluentValidation(config =>
        config.RegisterValidatorsFromAssemblyContaining<UpdateBairroValidator>())
    
    .AddFluentValidation(config =>
        config.RegisterValidatorsFromAssemblyContaining<CreateBairroValidator>());

builder.Services.AddTransient<ILogradouroRepository, LogradouroRepository>();
builder.Services.AddTransient<LogradouroHandler, LogradouroHandler>();

builder.Services.AddTransient<INumeroEnderecoRepository, NumeroEnderecoRepository>();
builder.Services.AddTransient<NumeroEnderecoHandler, NumeroEnderecoHandler>();

builder.Services.AddTransient<IBairroRepository, BairroRepository>();
builder.Services.AddTransient<BairroHandler, BairroHandler>();

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

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.MapControllers();

app.Run();