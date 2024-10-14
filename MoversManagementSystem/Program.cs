
using MMS.Application.Features.Movers.CreateQuote;
using MMS.Application.Features.persistence;
using MMS.Core.Entities;
using MMS.Infrastructure.persistence;
using MoversManagementSystem.ExceptionHandler;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IMovingQuotesRepository<MMS.Core.Entities.MovingQuotes>, DapperMovingQuotesRepository>();
builder.Services.AddMediatR(congif =>
{
    congif.RegisterServicesFromAssemblies(
        typeof(CreateQuotedCommand).Assembly,
        typeof(Program).Assembly,
        typeof(MovingQuotes).Assembly,
        typeof(DapperMovingQuotesRepository).Assembly);
});

builder.Host.UseSerilog((context, config) =>
{
    config.MinimumLevel.Override("Microsoft.AspNet", Serilog.Events.LogEventLevel.Information)
    .WriteTo.Console()
    .WriteTo.File("logs/app.txt", rollingInterval: RollingInterval.Day);
});   

var app = builder.Build();


app.UseMiddleware<ExceptionsHandlerMiddleWare>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(
    x =>
    {
        x.AllowAnyHeader();
        x.AllowAnyMethod();
        x.AllowAnyOrigin();
    });
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
