using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SuperOferta.Components;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SuperOferta.Data;
using SuperOferta.Models;
using Microsoft.AspNetCore.Components.Authorization;
using SuperOferta.Components.Account;


var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Supermercados;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False") ?? throw new InvalidOperationException("Connection string 'SupermercadoContextConnection' not found.");;
builder.Services.AddDbContext<SupermercadoContext>(options =>
{
    options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Supermercados;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
});
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<ISupermercadoService,SupermercadoService>();

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
/**
 * builder.Services.AddIdentity<Cliente, MyRol>()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<SupermercadoContext>();

builder.Services.AddIdentity<Cliente, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 8;
    //
    options.SignIn.RequireConfirmedEmail = false;
    //intentos para bloquear
    options.Lockout.AllowedForNewUsers = true;
    options.Lockout.MaxFailedAccessAttempts = 5;

})
    .AddEntityFrameworkStores<SupermercadoContext>()
    .AddDefaultTokenProviders();
 */




var app = builder.Build();
//builder.Services.AddRazorPages();
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


//app.MapGroup("/identity").MapIdentityApi<IdentityUser>();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapAdditionalIdentityEndpoints();;

app.Run();
