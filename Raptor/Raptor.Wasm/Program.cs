using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Raptor.Wasm;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var server = builder.Configuration.GetSection("ApiConfiguration")["BaseUrl"];

 
builder.Services.AddScoped(sp => 
    new HttpClient { BaseAddress = new Uri(server) });

await builder.Build().RunAsync();