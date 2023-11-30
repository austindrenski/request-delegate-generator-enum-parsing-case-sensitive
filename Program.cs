using System;
using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapGet("hello", static () => Results.Text("hello"));
app.MapGet("{enum}", static (SomeEnum @enum) => Results.Text($"{@enum}"));

await app.StartAsync();

using (var client = app.Services.GetRequiredService<HttpClient>())
{
    client.BaseAddress = new Uri("http://localhost:5000");

    // Capitalized
    using (var response = await client.GetAsync("Hello"))
    {
        response.EnsureSuccessStatusCode();
    }

    // Lowercase
    using (var response = await client.GetAsync("hello"))
    {
        response.EnsureSuccessStatusCode();
    }

    // Capitalized
    using (var response = await client.GetAsync("Some"))
    {
        response.EnsureSuccessStatusCode();
    }

    // Lowercase
    using (var response = await client.GetAsync("some"))
    {
        response.EnsureSuccessStatusCode();
    }
}

await app.WaitForShutdownAsync();

enum SomeEnum
{
    None,
    Some
}
