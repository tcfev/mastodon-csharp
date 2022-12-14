using Mastodon.Services;
using Microsoft.AspNetCore.Http.Extensions;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc().AddJsonTranscoding(options =>
{
    options.JsonSettings.WriteIndented = true;
});

builder.Services.AddGrpcReflection();

builder.Services.AddSingleton(new Mastodon.Client.MastodonClient(new Uri("https://mastodon.lol")));

var app = builder.Build();

app.UseGrpcWeb();

app.MapGrpcService<MastodonService>().EnableGrpcWeb();
app.MapGrpcReflectionService().EnableGrpcWeb();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client.");

app.MapFallback(async context =>
{
    var logger = ((IApplicationBuilder)app).ApplicationServices.GetService<ILogger<Program>>();
    var content = $"{context.Request.Method}: {context.Request.GetDisplayUrl()}";

    using var stream = context.Request.BodyReader.AsStream(true);
    using var reader = new StreamReader(stream, Encoding.UTF8, leaveOpen: true);

    var body = await reader.ReadToEndAsync();

    context.Response.StatusCode = 404;

    if (body != null && body.Length > 0)
    {
        content += "\r\n" + body;
    }

    logger?.LogError(content);
    await context.Response.WriteAsync(content);
});
app.Run();
