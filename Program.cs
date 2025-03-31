using ECommerceLabb.Components;
using ECommerceLabb.Services;
using ECommerceLabb.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddSingleton<ProductStateService>();
builder.Services.AddSingleton<CustomerStateService>();

builder.Services.AddHttpClient<ProductService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]!);
    Console.WriteLine($"HttpClient ProductService BaseAddress: {client.BaseAddress}");
});

builder.Services.AddHttpClient<CustomerService>(client =>
{
    var apiBaseUrl = builder.Configuration["ApiBaseUrl"];
    if (string.IsNullOrEmpty(apiBaseUrl))
    {
        throw new Exception("ApiBaseUrl is missing in configuration!");
    }

    client.BaseAddress = new Uri(apiBaseUrl);
    Console.WriteLine($"HttpClient CustomerService BaseAddress SET: {client.BaseAddress}");
});

builder.Services.AddHttpClient<OrderService>(client =>
{
    var apiBaseUrl = builder.Configuration["ApiBaseUrl"];
    if (string.IsNullOrEmpty(apiBaseUrl))
    {
        throw new Exception("ApiBaseUrl is missing in configuration!");
    }

    client.BaseAddress = new Uri(apiBaseUrl);
    Console.WriteLine($"HttpClient OrderService BaseAddress SET: {client.BaseAddress}");

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

