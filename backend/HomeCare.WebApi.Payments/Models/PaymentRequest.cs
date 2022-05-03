namespace HomeCare.WebApi.Payments.Models;

using HomeCare.Domain.Clients;
using HomeCare.Domain.Contracts;
using HomeCare.Domain.Payments;
using HomeCare.Domain.Suppliers;

internal class PaymentRequest
{
    public Guid Id { get; set; }
    public decimal Value { get; set; }
    public ContractRequest Contract { get; set; }

    public Payment ToModel()
    {
        return PaymentBuilder.Create()
            .WithValue(Value)
            .WithContract(Contract.ToModel(Value))
            .Build();
    }
}

internal class ContractRequest
{
    public Guid Id { get; set; }
    public UserRequest Client { get; set; }
    public UserRequest Supplier { get; set; }
    public string JobDescription { get; set; }
    public DateTime ExecutionDate { get; set; }

    public Contract ToModel(decimal price)
    {
        var client = Client.ToClient();
        var supplier = Supplier.ToSupplier();

        return Contract.Create()
            .With(client)
            .With(supplier)
            .With(price)
            .With(JobDescription)
            .With(ExecutionDate)
            .With(Id);
    }
}

internal class UserRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public Client ToClient()
    {
        return new Client
        {
            Id = Id,
            Email = Email,
            Name = Name,
        };
    }

    public Supplier ToSupplier()
    {
        return new Supplier
        {
            Id = Id,
            Email = Email,
            Name = Name,
        };
    }
}
