using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Midway.Gleybe.Application.IoC;
using Midway.Gleybe.Domain.Config;
using Midway.Gleybe.Infrastructure.Mapping;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Midway.Gleybe.Project", Version = "v1" });
});


// Configure additional services
var Configuration = builder.Configuration;

builder.Services.AddSession(options => {
    options.Cookie.Name = "UserLogged";
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AppRegister(Configuration);

builder.Services.Configure<MongoDbSettings>(Configuration.GetSection("MongoDbSettings"));

builder.Services.AddSingleton<IMongoDatabase>(serviceProvider =>
{
    var settings = serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    var client = new MongoClient(settings.ConnectionString);
    ClassMapping.Map();
    return client.GetDatabase(settings.DatabaseName);
});



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Midway.Gleybe.Project v1"));
}

app.UseSession();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.UseEndpoints(endpoints => {
    endpoints.MapControllers();
});

app.Run();

