using HomeCare.Domain.Suppliers;
using HomeCare.IoC;
using HomeCare.WebApi.Suppliers.Models;

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

app.MapGet("/suppliers/search", (long latitude, long longitude, long range, string? orderBy, string? serviceName, ISupplierService _supplierService) =>
{
    try
    {
        var criteria = new SearchCriteria
        {
            Location = new Location
            {
                Latitude = latitude,
                Longitude = longitude,
                Range = range,
            },
            SearchType = "price".Equals(orderBy, StringComparison.OrdinalIgnoreCase) ? SearchType.Price : SearchType.Quality,
            Tag = serviceName
        };

        var suppliers = _supplierService.Search(criteria);
        var response = suppliers.Select(s => SupplierSearchResponse.Parse(s));

        return Results.Ok(response);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex);
    }
})
.WithName("SearchSuppliers");

app.MapGet("/supplier", (Guid id, ISupplierService _supplierService) =>
{
    try
    {
        var supplier = _supplierService.GetById(id);
        var response = SupplierSearchResponse.Parse(supplier);

        return Results.Ok(response);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex);
    }
})
.WithName("GetSuppliers");

app.MapGet("/supplier/login", (string username, string password, ISupplierService _supplierService) =>
{
    try
    {
        var supplier = _supplierService.GetByUserName(username);
        var response = SupplierSearchResponse.Parse(supplier);

        return Results.Ok(response);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex);
    }
})
.WithName("GetLogin");

app.Run();