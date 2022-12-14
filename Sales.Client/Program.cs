using Microsoft.AspNetCore.Components;
using System.Web;
using Microsoft.AspNetCore.Components.Web;
using Sales.Client.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<ISellerService, SellerService>();
builder.Services.AddSingleton<IOpportunityService, OpportunityService>();
//alter BaseAdress
builder.Services.AddHttpClient("APIVENDAS", c => c.BaseAddress = new Uri("https://localhost:7001/")); 



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
