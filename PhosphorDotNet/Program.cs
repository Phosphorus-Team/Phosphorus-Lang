using System.Text.Json;

namespace PhosphorDotNet;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            throw new ArgumentException("Usage: PhosphorDotNet.exe <path>");
        }

        if (!Directory.Exists(args[0]))
        {
            throw new ArgumentException("Directory does not exist: " + args[0]);
        }

        string projectDetailsString;
        
        try
        {
            projectDetailsString = File.ReadAllText(Directory.GetFiles(args[0], "*.phproj")[0]);
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Could not read *.phproj file from directory: " + args[0], ex);
        }
        
        Project? project = JsonSerializer.Deserialize<Project>(projectDetailsString);
        Console.WriteLine(project.Name + " - " + project.Author + ":\n" + project.Scripts[0]);
    }
}