using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SuperOferta.Components;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SuperOferta.Data;
using SuperOferta.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using Microsoft.AspNetCore.Identity.UI.Services;
using SuperOferta.Components.Account;



var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Supermercados;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False") ?? throw new InvalidOperationException("Connection string 'SupermercadoContextConnection' not found.");;
//var connectionString = builder.Configuration.GetConnectionString("SuperOfertaContextConnection") ?? throw new InvalidOperationException("Connection string 'SuperOfertaContextConnection' not found.");;

builder.Services.AddDbContext<SupermercadoContext>(options =>
{
    options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Supermercados;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
});
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<ISupermercadoService,SupermercadoService>();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();

builder.Services.AddScoped<IdentityUserAccessor>();

builder.Services.AddScoped<IdentityRedirectManager>();

builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

builder.Services.AddIdentityCore<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<SupermercadoContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();
    


builder.Services.AddSingleton<IEmailSender<IdentityUser>, IdentityNoOpEmailSender>();
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

app.MapAdditionalIdentityEndpoints();;


app.Run();

