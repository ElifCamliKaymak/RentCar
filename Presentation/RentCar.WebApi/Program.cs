using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RentCar.Application.Tools;
using RentCar.Persistance.Context;
using RentCar.WebApi.Extensions;
using RentCar.WebApi.Mapping;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidAudience = JwtTokenDefaults.ValidAudience,
        ValidIssuer = JwtTokenDefaults.ValidIssuer,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddScoped<RentCarContext>();

builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.ConfigureRepositoryRegistration();
builder.Services.ConfigureAboutRegistration();
builder.Services.ConfigureBannerRegistration();
builder.Services.ConfigureBrandRegistration();
builder.Services.ConfigureCarRegistration();
builder.Services.ConfigureCategoryRegistration();
builder.Services.ConfigureContactRegistration();
builder.Services.ConfigureCommentRegistration();

builder.Services.AddMediatorServices(builder.Configuration);

builder.Services.AddControllers().AddFluentValidation(x=>
{
    x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
