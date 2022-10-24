using Finance.Api;
using Finance.Application;
using Finance.Domain;
using Finance.Infra;
using Finance.Infra.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<FinanceDbContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("POSTGRESQL")));


// Project DI and configurations
builder.Services.AddApi();
builder.Services.AddApplication();
builder.Services.AddDomain();
builder.Services.AddInfra();


//builder.Services.AddScoped<FinanceDbContext, FinancePostgresContext>();


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
