using Finance.Api;
using Finance.Application;
using Finance.Domain;
using Finance.Infra;
using Finance.Infra.Postgresql;
using Finance.Infra.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Project DI and configurations
builder.Services.AddApi();
builder.Services.AddApplication();
builder.Services.AddDomain();
builder.Services.AddInfra();

builder.Services.AddScoped<IDBContext, PostgreContext>();

builder.Services.AddDbContext<FinanceDbContext>(option =>
    option.UseNpgsql(builder.Configuration.GetConnectionString("POSTGRESQL")));


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
