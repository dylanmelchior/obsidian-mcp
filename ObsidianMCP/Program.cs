using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol;
using ObsidianMCP.Services;
using ObsidianMCP.Tools;
using System.Net.Http.Headers;

var builder = Host.CreateEmptyApplicationBuilder(settings: null);

builder.Services.AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();

builder.Services.AddSingleton(_ =>
{
    var vaultPath = "C:\\Users\\dmelc\\Desktop\\Obsidian\\Dylan's Vault";
    return new VaultReader(vaultPath);
});

builder.Services.AddSingleton(_ =>
{
    var vaultPath = "C:\\Users\\dmelc\\Desktop\\Obsidian\\Dylan's Vault";
    return new SearchService(vaultPath);
});

builder.Services.AddSingleton<ObsidianTools>();

var app = builder.Build();

await app.RunAsync();