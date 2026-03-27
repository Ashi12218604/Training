using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// 1. Tell the app to read your custom ocelot.json file
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// 2. Inject the Ocelot services into the builder
builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

app.UseHttpsRedirection();

// 3. Turn on the Ocelot routing engine
await app.UseOcelot();

app.Run();