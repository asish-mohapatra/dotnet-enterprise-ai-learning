using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("================================");
        Console.WriteLine("   DOTNET ENVIRONMENT REPORT");
        Console.WriteLine("================================");

        //Display the application name.
        Console.WriteLine($"Application Name: {System.Diagnostics.Process.GetCurrentProcess().ProcessName}");

        //Display the runtime version.
        Console.WriteLine($"Runtime Version: {Environment.Version}");

        //Display the operating system.
        Console.WriteLine($"Operating System: {Environment.OSVersion}");

        //Display the machine name.
        Console.WriteLine($"Machine Name: {Environment.MachineName}");

        //Ask the user to enter their name.
        Console.Write("Please enter your name: ");
        string? name = Console.ReadLine();

        //Ask the user to enter their city.
        Console.Write("Please enter your city: ");
        string? city = Console.ReadLine();

        //Display a welcome message.
        if (!string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine($"Welcome, {name}!");
        }
        else
        {
            Console.WriteLine("Welcome, Developer!");
        }

        Console.WriteLine($"City: {city}");

        //Display the current date and time.
        Console.WriteLine($"Current Date and Time: {DateTime.Now}");

        //Display a completion message.
        Console.WriteLine("Environment report completed.");

    }
}