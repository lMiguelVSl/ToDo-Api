using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ToDo.Api.Startup;
using ToDo.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var secretKey = builder.Configuration["Jwt:SecretKey"] ?? throw new InvalidOperationException();
var issuer = builder.Configuration["Jwt:Issuer"] ?? throw new InvalidOperationException();
var audience = builder.Configuration["Jwt:Audience"] ?? throw new InvalidOperationException();
var urlAllowed = builder.Configuration["AppSettings:urlHost"] ?? throw new InvalidOperationException();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = issuer,
            ValidAudience = audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey).ToArray())
        };
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(x =>
        x.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
}

if (!app.Environment.IsDevelopment())
{
    app.UseCors(x =>
        x.WithOrigins(urlAllowed)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseHttpsRedirection();

app.Run();