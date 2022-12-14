using Mastodon.Service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc().AddJsonTranscoding(options =>
{
    options.JsonSettings.WriteIndented = true;
});

builder.Services.AddSingleton(new Mastodon.Client.MastodonClient(new Uri("https://mastodon.lol")));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<InstnaceService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client.");

app.Run();
