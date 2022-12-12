using Pandora.Infra.Postgresql;
using Pandora.Infra.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

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

var key = Encoding.ASCII.GetBytes("super-secret-key");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = false;
        x.TokenValidationParameters = new()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
