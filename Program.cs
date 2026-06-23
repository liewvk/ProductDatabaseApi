using Microsoft.EntityFrameworkCore;
using ProductDatabaseApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductDb")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ProductDbContext>();

    db.Database.EnsureCreated();

    if (!db.Products.Any())
    {
        db.Products.AddRange(
            new Product { Name = "Laptop", Category = "Electronics", Price = 3500, Quantity = 5 },
            new Product { Name = "Mouse", Category = "Accessories", Price = 45, Quantity = 20 },
            new Product { Name = "Keyboard", Category = "Accessories", Price = 120, Quantity = 10 }
        );

        db.SaveChanges();
    }
}

app.UseHttpsRedirection();

app.MapGet("/api/products", async (ProductDbContext db) =>
{
    List<Product> products = await db.Products.ToListAsync();

    return Results.Ok(products);
});

app.MapGet("/api/products/{id}", async (int id, ProductDbContext db) =>
{
    Product? product = await db.Products.FindAsync(id);

    return product is null ? Results.NotFound() : Results.Ok(product);
});

app.MapPost("/api/products", async (Product product, ProductDbContext db) =>
{
    db.Products.Add(product);
    await db.SaveChangesAsync();

    return Results.Created($"/api/products/{product.Id}", product);
});

app.MapPut("/api/products/{id}", async (int id, Product updatedProduct, ProductDbContext db) =>
{
    Product? product = await db.Products.FindAsync(id);

    if (product is null)
        return Results.NotFound();

    product.Name = updatedProduct.Name;
    product.Category = updatedProduct.Category;
    product.Price = updatedProduct.Price;
    product.Quantity = updatedProduct.Quantity;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/api/products/{id}", async (int id, ProductDbContext db) =>
{
    Product? product = await db.Products.FindAsync(id);

    if (product is null)
        return Results.NotFound();

    db.Products.Remove(product);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();
