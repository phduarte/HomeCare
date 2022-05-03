using HomeCare.Domain.Payments;
using HomeCare.IoC;
using HomeCare.WebApi.Payments.Models;

var builder = WebApplication.CreateBuilder(args);

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

app.MapGet("/payments", (IPaymentService _paymentService) =>
{
    try
    {
        var payments = _paymentService.GetAll();
        return Results.Ok(payments);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex);
    }
})
.WithName("GetPayments");

app.MapGet("/payments/by-contract/{id}", (Guid id, IPaymentService _paymentService) =>
{
    try
    {
        var payment = _paymentService.GetAllByContract(id);
        PaymentSummaryResponse response = PaymentSummaryResponse.Parse(payment);

        return Results.Ok(response);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex);
    }
})
.WithName("GetPaymentsByContract");

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
        return Results.Ok($"O pagamento foi confirmado");
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex);
    }
})
.WithName("CompletePayment");

app.Run();
