namespace TestProject1.utility;

using System.Collections.Generic;
using System.IO;

public static class EnvLoader
{
    private static readonly string EnvFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ENV", ".env");

    public static Dictionary<string, string> Load()
    {
        var envVariables = new Dictionary<string, string>();
        if (File.Exists(EnvFilePath))
        {
            foreach (var line in File.ReadAllLines(EnvFilePath))
            {
                var parts = line.Split('=', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 2)
                {
                    envVariables[parts[0].Trim()] = parts[1].Trim();
                }
            }
        }
        return envVariables;
    }
}