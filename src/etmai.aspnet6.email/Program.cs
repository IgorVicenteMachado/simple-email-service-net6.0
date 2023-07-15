using etmai.aspnet6.email.Extentions;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.LoadSecretsValues();
builder.Services.LoadDependencyInjection();
builder.Services.AddMemoryCache();
builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCorsConfiguration();
builder.Services.AddControllers();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCorsConfiguration();
app.UseHttpsRedirection();

app.MapControllers();

app.Run();
