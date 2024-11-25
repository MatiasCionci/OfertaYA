using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SuperOferta.Components;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SuperOferta.Data;
using SuperOferta.Models;
using Microsoft.AspNetCore.Components.Authorization;
using SuperOferta.Components.Pages.Account;
using Blazored.LocalStorage;


var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Supermercados;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False") ?? throw new InvalidOperationException("Connection string 'SupermercadoContextConnection' not found.");;
builder.Services.AddDbContext<SupermercadoContext>(options =>
{
    options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Supermercados;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
});
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<ISupermercadoService,SupermercadoService>();

builder.Services.AddScoped<ServiceRol>();
builder.Services.AddCascadingAuthenticationState();

builder.Services.AddScoped<IdentityUserAccessor>();





builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<DbContext,SupermercadoContext>();

builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();


builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

builder.Services.AddIdentityCore<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<SupermercadoContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<IdentityUser>, IdentityNoOpEmailSender>();


builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
var app = builder.Build();
app.MapGet("/", context =>
{
    context.Response.Redirect("/home");
    return Task.CompletedTask;
});
//builder.Services.AddRazorPages();
// Configure the HTTP request pipeline.

using (var scope = app.Services.CreateScope())
{
  
    string[] roles = ["Admin", "Cliente", "Partner"];
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
 
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            IdentityRole roleRole = new IdentityRole(role);
            await roleManager.CreateAsync(roleRole);
        }
    }
   
     
}
//

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();


app.UseStaticFiles();
app.UseAntiforgery();


//app.MapGroup("/identity").MapIdentityApi<IdentityUser>();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapAdditionalIdentityEndpoints();;

app.Run();
