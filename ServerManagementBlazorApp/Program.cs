using Microsoft.EntityFrameworkCore;
using ServerManagementBlazorApp.Components;
using ServerManagementBlazorApp.Data;
using ServerManagementBlazorApp.Models;
using ServerManagementBlazorApp.StateStore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<ServerManagementContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ServerManagement"));
});

builder.Services.AddTransient<SessionStorage>();
builder.Services.AddScoped<ContainerStorage>();
builder.Services.AddScoped<ChennaiOnlineServerStore>();
builder.Services.AddScoped<MaduraiOnlineServerStore>();

builder.Services.AddTransient<IServersEFCoreRepository, ServersEFCoreRepository>();

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

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

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
