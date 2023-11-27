using RentCar.Persistance.Context;
using RentCar.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<RentCarContext>();

builder.Services.ConfigureRepositoryRegistration();
builder.Services.ConfigureAboutRegistration();
builder.Services.ConfigureBannerRegistration();
builder.Services.ConfigureBrandRegistration();
builder.Services.ConfigureCarRegistration();
builder.Services.ConfigureCategoryRegistration();
builder.Services.ConfigureContactRegistration();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
