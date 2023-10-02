using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;
using CommunicationService.Services;
using Polly;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Brug Polly til retry af http requests
builder.Services.AddHttpClient<IEmailSendApiService, EmailSendApiService>()
    .AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(
        3, attempt => TimeSpan.FromMilliseconds(100 * Math.Pow(2, attempt))));

builder.Services.Scan(selector => selector.FromAssemblyOf<IEmailSendApiService>()
.AddClasses(classes => classes.AssignableTo<IEmailSendApiService>())
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

//Email - servicen findes p� denne adresse: https://twilioproxy.azurewebsites.net/api/SendEmail?code=qMTJzZtnKGD4c0LgyYHyepoT7VdFOir1Wig9yrU6LeQLAzFuCJeiWw==

//Den modtager data med post. Det skal v�re et json-objekt med f�lgende v�rdier

//receiver - modtagerens email-adresse
//message - beskedens indhold
//subject - beskedes titel
//html - besked formatteret i html (valgfrit)
//Der er f�lgende begr�nsninger af servicen:

//Alle e-mails sendes fra min adresse (ktlh@smartlearning.dk)
//Du kan kun sende til din smartlearning eller cphbusiness-adresse.



//SMS - servicen findes p� denne adresse: https://twilioproxy.azurewebsites.net/api/SendSMS?code=biIj0VMV608PIppCMrQDNn477AqqA7-w4a7mE8kug2HvAzFuxgovmQ==

//Den kaldes med post med et json-objekt som body. Objektet skal indeholde disse attributter:

//receiver - telefonnummeret p� modtageren. Skal starte med +45
//key - din unikke n�gle som giver dig adgang til at sende til din egen telefon
//message - den besked der skal sendes


//Begr�nsninger i servicen:

//Alle beskeder sendes fra det samme afsender nummer
//Du kan kun sende til dit eget telefonnummer.