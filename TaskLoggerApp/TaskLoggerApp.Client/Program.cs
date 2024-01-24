using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
//builder.RootComponents.Add<App>("#app");

// Configure HTTP client with the base address of your API
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5217") });

await builder.Build().RunAsync();
