using FluentValidation.AspNetCore;
using RentCar.Persistance.Context;
using RentCar.WebApi.Extensions;
using RentCar.WebApi.Hubs;
using RentCar.WebApi.Mapping;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();
// Add services to the container.
builder.Services.CongifureJwtRegistration();
builder.Services.ConfigureSignalRRegistration();
builder.Services.AddSignalR();

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

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHub<CarHub>("/carhub");

app.Run();
