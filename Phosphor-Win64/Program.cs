using System.Text.Json;

namespace Phosphor_Win64;

internal class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Usage: Phosphor-Win64.exe <PROJECT DIRECTORY>");
            return;
        }

        if (!Directory.Exists(args[0]))
        {
            Console.WriteLine("Directory does not exist: {0}", args[0]);
            return;
        }

        if (Directory.GetFiles(args[0], "*.phproj").Length != 1)
        {
            Console.WriteLine("Could not find .phproj file.\n(Did you add multiple or forget to add one?)");
            return;
        }
        
        string jsonString = File.ReadAllText(Directory.GetFiles(args[0], "*.phproj")[0]);
        Project? project = JsonSerializer.Deserialize<Project>(jsonString);

        foreach (string script in project.Scripts)
        {
            Console.WriteLine(script);
        }
    }
}

public class Project
{
    public required string Name { get; set; }
    public required string Type { get; set; }
    public required string Author { get; set; }
    public required string[] Scripts { get; set; }
}