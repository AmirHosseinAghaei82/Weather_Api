using WeatherApi.Services;
using WeatherApi.Services.Interfaces;
using WeatherApi.Services.Helper.WeatherHelper;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddScoped<GeoCoordinatesHelper>();
builder.Services.AddScoped<WeatherApiResponseHelper>();
builder.Services.AddScoped<AirPollutionHelper>();
builder.Services.AddScoped<IWeatherService, WeatherService>();

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

app.MapControllers();

app.Run();

