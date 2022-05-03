using HomeCare.Domain.Payments;
using HomeCare.IoC;
using HomeCare.WebApi.Payments.Models;

//using HomeCare.WebApi.Contracts.Model;

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

app.MapGet("/payment/{id}", (Guid id, IPaymentService _paymentService) =>
{
    try
    {
        var payment = _paymentService.GetById(id);
        return Results.Ok(payment);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex);
    }
})
.WithName("GetPayment");

app.MapPost("/payment/request", (PaymentRequest request, IPaymentService _paymentService) =>
{
    try
    {
        var model = request.ToModel();
        var receipt = _paymentService.Request(model);
        return Results.Ok(receipt);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex);
    }
})
.WithName("RequestPayment");

app.MapPost("/payment/refund", (PaymentRefundRequest request, IPaymentService _paymentService) =>
{
    try
    {
        var receipt = _paymentService.Refund(request.Id);
        var response = PaymentRefundResponse.Parse(receipt);
        return Results.Ok(receipt);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex);
    }
})
.WithName("RefundPayment");

app.MapPost("/payment/confirm", (PaymentRefundRequest request, IPaymentService _paymentService) =>
{
    try
    {
        _paymentService.Confirm(request.Id);
        //var response = PaymentConfirmResponse.Parse(request);
        return Results.Ok($"O pagamento foi confirmado");
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex);
    }
})
.WithName("CompletePayment");

app.Run();
