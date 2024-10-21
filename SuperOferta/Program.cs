using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SuperOferta.Components;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SuperOferta.Data;
using SuperOferta.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddDbContext<SupermercadoContext>(options =>
{
    options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Supermercados;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
});
builder.Services.AddScoped<ISupermercadoService,SupermercadoService>();
builder.Services.AddIdentity<Cliente, MyRol>(options =>
{
    options.Password.RequireDigit= true;
    options.Password.RequireLowercase= true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 8;
    //
    options.SignIn.RequireConfirmedEmail = false;
    //intentos para bloquear
    options.Lockout.AllowedForNewUsers = true;
    options.Lockout.MaxFailedAccessAttempts = 5;

})
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<SupermercadoContext>();



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

app.MapGroup("/identity").MapIdentityApi<IdentityUser>();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
