using Microsoft.EntityFrameworkCore;
using Plugins.DataSore.SQL;
using Plugins.DateStore.SQL;
using Supermarket_management.Data;
using UseCases;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();


// Dependency Injection for In-Memory Data
//builder.Services.AddScoped<ICategoryRepository, CategoryInMemoryRepository>();
//builder.Services.AddScoped<IProductRepository, ProductInMemoryRepository>();
//builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();


// Dependency Injection for entity framwork(ef) DataStore
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

// Dependency Injection for Use Case
builder.Services.AddTransient<ICategoryUseCase, CategoryUseCase>();
builder.Services.AddTransient<IProductUseCase, ProductUseCase>();
builder.Services.AddTransient<ISellProductUseCase, SellProductUseCase>();
builder.Services.AddTransient<ITransactionUseCase, TransactionUseCase>();


var connectionString = builder.Configuration.GetConnectionString("DevConnection");
builder.Services.AddDbContext<Supermarket_managementContext>(options =>
    options.UseSqlServer(connectionString));builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<Supermarket_managementContext>();builder.Services.AddDbContext<ApplicationContext>(option =>
    option.UseSqlServer(connectionString));

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", p => p.RequireClaim("Position","Admin"));
    options.AddPolicy("CashierOnly", p => p.RequireClaim("Position","Cashier"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
