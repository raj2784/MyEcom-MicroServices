using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductCatalog.BusinessObject;
using ProductCatalog.EFRepositories;
using ProductCatalog.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProductCatalogContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductCatalogContext")
    ?? throw new InvalidOperationException("Connection string 'ProductCatalogContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICatalogItemBO,CatalogItemBO>();
builder.Services.AddTransient<ICatalogItemRepository,CatalogItemRepository>();
builder.Services.AddTransient<ICatalogBrandBO,CatalogBrandBO>();
builder.Services.AddTransient<ICatalogBrandRepository, CatalogBrandRepository>();
builder.Services.AddTransient<ICatalogTypeBO, CatalogTypeBO>();
builder.Services.AddTransient<ICatalogTypeRepository, CatalogTypeRepository>();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    //try
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<ProductCatalogContext>();
        context.Database.Migrate();
        ProductCatalogSeed.SeedAsync(context).Wait();
    }
    //catch(Exception ex)
    //{
    //    var logger = services.GetRequiredService<ILogger<Program>>();
    //    logger.logError(ex, "An error occurred while trying creating the DB.");
    //}
}

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
