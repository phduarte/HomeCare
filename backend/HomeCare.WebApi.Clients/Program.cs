using HomeCare.Domain.Aggregates.Clients;
using HomeCare.IoC;
using HomeCare.WebApi.Clients.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHomeCare(builder.Configuration);

var app = builder.Build();

if (app.Configuration.GetValue<bool>("UseSwagger"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/clients", (IClientService clientsService) =>
{
    try
    {
        var model = clientsService.GetAll().Select(client => ClientResponse.Parse(client));
        return Results.Ok(model);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex);
    }
})
.WithName("GetAllClients");

app.MapGet("/client", (Guid id, IClientService clientsService) =>
{
    if (clientsService.GetById(id) is Client client)
    {
        return Results.Ok(ClientResponse.Parse(client));
    }
    else
    {
        return Results.NotFound();
    }
})
.WithName("GetClientById");

app.MapPost("/client/login", (string username, string password, IClientService clientsService) =>
{
    if (clientsService.GetByUsername(username) is Client client)
    {
        return Results.Ok(ClientResponse.Parse(client));
    }
    else
    {
        return Results.NotFound();
    }
})
.WithName("Login");

app.Run();