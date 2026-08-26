using FastPay.Core.Api.Http;
using FastPay.Core.Domain;
using FastPay.Transactions.Api;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddAppContext<Program>(configuration);
builder.Services.AddDomainContext(configuration);
builder.Services.AddApplicationBootstrapper(configuration);
builder.Services.AddSettings(configuration);

var app = builder.Build();
app.UseApplicationContext();
app.UseCors();
app.Run();