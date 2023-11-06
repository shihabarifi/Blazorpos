using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using pos.Data;
using pos.IRepository;
using pos.Models;
using pos.Repositories;
using pos.Services;
using POS.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddScoped<IRepository<Unit>, UnitRepo>();
builder.Services.AddScoped<IRepository<Category>, CaregoryRepo>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IProduct<Product>, ProductRepo>();
builder.Services.AddScoped<IInvoice<Invoice>, InvoiceRepo>();
builder.Services.AddDbContext<posDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
