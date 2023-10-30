using CommunicationService.Services;
using Polly;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// For at kunne læse fra user secrets via configurattion
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Brug Polly til retry af http requests
builder.Services.AddHttpClient<ISmsSendApiService, SmsSendApiService>()
    .AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(
        3, attempt => TimeSpan.FromMilliseconds(100 * Math.Pow(2, attempt))));

builder.Services.Scan(select => select.FromAssemblyOf<ISmsSendApiService>()
.AddClasses(classs => classs.AssignableTo<ISmsSendApiService>())
.AsImplementedInterfaces());
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

