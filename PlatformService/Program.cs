/*using Microsoft.EntityFrameworkCore;
using PlatfromService.Data;
 
var builder = WebApplication.CreateBuilder(args);
 
// Add services to the container.

Console.WriteLine("Inmem");
builder.Services.AddDbContext<AppDBContext>(opt => opt.UseInMemoryDatabase("InMem"));

 
builder.Services.AddScoped<IPlatformRepo, PlatformRepo>();
//builder.Services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();
//builder.Services.AddSingleton<IMessageBusClient, MessageBusClient>();
//builder.Services.AddGrpc();

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 
Console.WriteLine($"---> CommandService Endpoint {builder.Configuration["CommandService"]}");
 
var app = builder.Build();
 
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
 
//app.UseHttpsRedirection();
 
//app.MapGrpcService<GrpcPlatformService>();
//TODO Not mandatory endpoint serve
 
app.UseAuthorization();
 
app.MapControllers();
 
PrepDb.PrepPopulation(app);
 
app.Run();
*/

using Microsoft.EntityFrameworkCore;
using PlatfromService.Data;
using PlatfromService.DTOs;
using PlatfromService.Models; 
var builder = WebApplication.CreateBuilder(args);

 
// Add services to the container.
 /*
if(builder.Environment.IsProduction())
{
    Console.WriteLine("---> Using Postgre DB");
   builder.Services.AddDbContext<AppDBContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
}
else
{*/
    Console.WriteLine("---> Using InMemory DB");
    builder.Services.AddDbContext<AppDBContext>(opt => opt.UseInMemoryDatabase("InMem"));

 
builder.Services.AddScoped<IPlatformRepo, PlatformRepo>();
//builder.Services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();
//builder.Services.AddSingleton<IMessageBusClient, MessageBusClient>();
//builder.Services.AddGrpc();
 
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 
Console.WriteLine($"---> CommandService Endpoint {builder.Configuration["CommandService"]}");
 
var app = builder.Build();
 
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
 
//app.UseHttpsRedirection();
 
//app.MapGrpcService<GrpcPlatformService>();
//TODO Not mandatory endpoint serve
 
app.UseAuthorization();
 
app.MapControllers();
 
PrepDb.PrepPopulation(app);
 
app.Run();