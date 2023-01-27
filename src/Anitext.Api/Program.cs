using Anitext.Api.Options;
using Anitext.Api.Registrars;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiVersioning(o =>
{
    o.DefaultApiVersion = ApiVersion.Default;
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.ReportApiVersions = false;
    o.ApiVersionReader = new UrlSegmentApiVersionReader();
});

builder.Services.AddControllers();
builder.Services.AddSwaggerServices();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

if (app.Environment.IsDevelopment())
    app.UseSwaggerServices();

app.MapControllers();

app.Run();
