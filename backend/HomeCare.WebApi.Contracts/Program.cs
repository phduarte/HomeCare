using HomeCare.Domain.Contracts;
using HomeCare.IoC;
using HomeCare.WebApi.Contracts.Model;

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

app.MapGet("/contract/{id}", (Guid id, IContractService contractService) =>
{
    try
    {
        var contract = contractService.GetById(id);

        return Results.Ok(contract);
    }
    catch (ContractNotFoundException)
    {
        return Results.NotFound();
    }
    catch (ContractIsNotPendingException)
    {
        return Results.UnprocessableEntity();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex);
    }
})
.WithName("GetContract");

app.MapPost("/contract/emit", (ContractEmitRequest request, IContractService contractService) =>
{
    try
    {
        var sketch = request.ToModel();
        var contract = contractService.Emit(sketch);
        var response = ContractResponse.Parse(contract);

        return Results.Ok(response);
    }
    catch (ContractNotFoundException)
    {
        return Results.NotFound();
    }
    catch (ContractIsNotPendingException)
    {
        return Results.UnprocessableEntity();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex);
    }
})
.WithName("EmitContract");

app.MapPost("/contract/cancel", (ContractRequest request, IContractService contractService) =>
{
    try
    {
        contractService.Cancel(request.ContractId);
        return Results.Ok($"Contrato {request.ContractId} foi cancelado.");
    }
    catch (ContractNotFoundException)
    {
        return Results.NotFound();
    }
    catch (ContractIsNotPendingException)
    {
        return Results.UnprocessableEntity();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex);
    }
})
.WithName("CancelContract");

app.MapPost("/contract/finish", (ContractRequest request, IContractService contractService) =>
{
    try
    {
        contractService.Finish(request.ContractId);
        return Results.Ok($"Contrato {request.ContractId} foi finalizado.");
    }
    catch (ContractNotFoundException)
    {
        return Results.NotFound();
    }
    catch (ContractIsNotPendingException)
    {
        return Results.UnprocessableEntity();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex);
    }
})
.WithName("FinishContract");

app.Run();