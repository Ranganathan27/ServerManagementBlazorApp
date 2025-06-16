using WebAssemblyDemo.Client;
using WebAssemblyDemo.Client.Models;
using WebAssemblyDemo.Client.Pages;
using WebAssemblyDemo.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddSingleton<ContainerStorage>();

builder.Services.AddHttpClient("ServersAPI", client =>
{
    client.BaseAddress = new Uri("https://webassemblydemo-222a1-default-rtdb.asia-southeast1.firebasedatabase.app/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddTransient<IServersRepository, ServersAPIRepository>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(WebAssemblyDemo.Client._Imports).Assembly);

app.Run();
