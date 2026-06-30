using System.Text.RegularExpressions;
using backend_csharp.Data;

namespace backend_csharp.Services;

public sealed class DatabaseSetupService
{
    private readonly DbConnectionFactory _db;
    private readonly IConfiguration _configuration;
    private readonly IWebHostEnvironment _environment;

    public DatabaseSetupService(
        DbConnectionFactory db,
        IConfiguration configuration,
        IWebHostEnvironment environment)
    {
        _db = db;
        _configuration = configuration;
        _environment = environment;
    }

    public async Task<IReadOnlyList<string>> RecreateAndSeedAsync()
    {
        var executed = new List<string>();
        await ExecuteScriptAsync(GetScriptPath("Schema"), executed);
        await ExecuteScriptAsync(GetScriptPath("Seed"), executed);
        return executed;
    }

    private string GetScriptPath(string key)
    {
        var configuredPath = _configuration[$"DatabaseScripts:{key}"]
            ?? throw new InvalidOperationException($"Missing DatabaseScripts:{key}.");

        var fullPath = Path.GetFullPath(Path.Combine(_environment.ContentRootPath, configuredPath));
        if (!File.Exists(fullPath))
        {
            throw new FileNotFoundException($"SQL script not found: {fullPath}");
        }

        return fullPath;
    }

    private async Task ExecuteScriptAsync(string path, List<string> executed)
    {
        var script = await File.ReadAllTextAsync(path);
        var batches = Regex.Split(script, @"^\s*GO\s*;?\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase)
            .Select(x => x.Trim())
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .ToList();

        await using var connection = _db.CreateMasterConnection();
        await connection.OpenAsync();

        foreach (var batch in batches)
        {
            await SqlHelpers.ExecuteAsync(connection, batch);
        }

        executed.Add($"{Path.GetFileName(path)}: {batches.Count} batches");
    }
}
