using Pandora.Infra.Postgresql;
using Pandora.Infra.Repository.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Project DI and configurations
builder.Services
    .AddApi()
    .AddApplication()
    .AddInfra();

builder.Services.AddScoped<IDatabaseContext, PostgresqlContext>();

builder.Services.AddDbContext<DatabaseContext>(option =>
    option.UseNpgsql(builder.Configuration.GetConnectionString("POSTGRESQL")));

builder.Services.AddCors();

var app = builder.Build();

app.UseCors(op => op
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());

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
