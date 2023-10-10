namespace TestProject1.utility;

using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class EnvReader
{
    public static Dictionary<string, string> Load(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        return lines
            .Select(line => line.Split('='))
            .ToDictionary(parts => parts[0], parts => parts[1]);
    }
}