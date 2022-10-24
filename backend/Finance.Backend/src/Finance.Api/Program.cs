using Finance.Api;
using Finance.Application;
using Finance.Domain;
using Finance.Infra;


var builder = WebApplication.CreateBuilder(args);

// Project DI and configurations
builder.Services.AddApi();
builder.Services.AddApplication();
builder.Services.AddDomain();
builder.Services.AddInfra();

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
