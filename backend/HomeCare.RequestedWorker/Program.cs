using HomeCare.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<HomeCare.RequestedWorker.SendMessageBackgroundService>();
builder.Services.AddHomeCare(builder.Configuration);

var app = builder.Build();

app.Run();