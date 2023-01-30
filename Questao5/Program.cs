using FluentAssertions.Common;
using MediatR;
using Microsoft.AspNetCore.Connections;
using Microsoft.Extensions.DependencyInjection;
using Questao5.Application.Queries.Requests;
using Questao5.Application.Queries.Responses;
using Questao5.Infrastructure;
using Questao5.Infrastructure.Database;
using Questao5.Infrastructure.Database.QueryStore;
using Questao5.Infrastructure.Interfaces;
using Questao5.Infrastructure.Sqlite;
using Questao5.Repositories;
using System;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Adicione os serviços ao contêiner.
builder.Services.AddControllers();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// sqlite
builder.Services.AddSingleton(new DatabaseConfig { Name = builder.Configuration.GetValue<string>("DatabaseName", "Data Source=database.sqlite") });
builder.Services.AddSingleton<IDatabaseBootstrap, DatabaseBootstrap>();

// Saiba mais sobre configurar Swagger/OpenAPI em https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure o pipeline de solicitação HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();


var connectionString = "Data Source=banco.db;";
var connectionFactory = new ConnectionFactory(connectionString);
builder.Services.AddScoped<Questao5.Infrastructure.Interfaces.IConnectionFactory, ConnectionFactory>();
builder.Services.AddScoped<IQueryStore<AccountBalanceQueryRequest, AccountBalanceQueryResponse>, AccountBalanceQueryStore>();


// sqlite
#pragma warning disable CS8602 // Dereference of a possibly null reference.
app.Services.GetService<IDatabaseBootstrap>().Setup();
#pragma warning restore CS8602 // Dereference of a possibly null reference.

app.Run();

// Informações úteis:
// Tipos do Sqlite - https://www.sqlite.org/datatype3.html


