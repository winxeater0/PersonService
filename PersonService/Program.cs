using Autofac;
using Autofac.Extensions.DependencyInjection;
using Confluent.Kafka;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PersonService.Infrastructure.CrossCutting.IOC;
using PersonService.Infrastrusture.Data;
using imobiSystem.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(i =>
{
    i.SwaggerDoc("v1", new OpenApiInfo { Title = "Person API Service", Version = "v1" });
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(
   builder => builder.RegisterModule(new ModuleIOC()));

builder.Services.AddDbContext<SqlContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("PersonService.API")));

builder.Services.AddKafkaClient();
builder.Services.AddSingleton<PersonManager>();
//pega a section no appsettings

#region Consumer que vai pro BFF
var config = new ConsumerConfig
{
    BootstrapServers = "127.0.0.1:9092",
    GroupId = "MyGroupId",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
consumer.Subscribe("my-topic");

var result = consumer.Consume();
Console.WriteLine($"Received: {result.Message.Value}");
#endregion

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

