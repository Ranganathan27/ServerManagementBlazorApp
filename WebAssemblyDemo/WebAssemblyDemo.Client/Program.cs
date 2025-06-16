using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebAssemblyDemo.Client;
using WebAssemblyDemo.Client.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddSingleton<ContainerStorage>();

builder.Services.AddHttpClient("ServersAPI", client =>
{
    client.BaseAddress = new Uri("https://webassemblydemo-222a1-default-rtdb.asia-southeast1.firebasedatabase.app/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddTransient<IServersRepository, ServersAPIRepository>();

await builder.Build().RunAsync();
