using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Tarea6Lab.Data;
using Blazored.Toast;
using Microsoft.EntityFrameworkCore;
using Tarea6Lab.DAL;
using Tarea6Lab.BLL;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddBlazoredToast(); // Toast
builder.Services.AddTransient<ProductoBLL>(); // BLL

// Aqui inyectamos el DbContext
builder.Services.AddDbContext<Contexto>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("ConStr"))    
);

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
