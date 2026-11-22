Console.WriteLine("===================================");
Console.WriteLine("     Dotnet Day 01 Application     ");
Console.WriteLine("===================================");

Console.WriteLine();

Console.WriteLine("Application Name: Dotnet Day 01");

Console.WriteLine($"Framework Version: {Environment.Version}");

Console.WriteLine($"Operating System: {Environment.OSVersion}");

Console.WriteLine($"Machine Name: {Environment.MachineName}");

Console.WriteLine();

Console.WriteLine("Learning Objectives:");

Console.WriteLine("1. Understanding C#");
Console.WriteLine("2. Understanding .NET");
Console.WriteLine("3. Understanding CLR");
Console.WriteLine("4. Understanding compilation");
Console.WriteLine("5. Understanding .NET CLI");

Console.WriteLine();

Console.WriteLine("Day 1 completed successfully!");

//Exercise 1 – Basic output

Console.WriteLine("My Name : Asish Mohapatra");
Console.WriteLine("My Technology : C# and .NET");
Console.WriteLine("My Platform : .NET 11");
Console.WriteLine("My Learning Goal : Enterprise .NET Architecture");

//Exercise 2 – User input
Console.Write("Enter your name: ");
string? name = Console.ReadLine();
Console.Write("Enter your age: ");
string? ageInput = Console.ReadLine();
Console.Write("Enter your City: ");
string? city = Console.ReadLine();

Console.WriteLine($"Hello, {name}! You are {ageInput} years old and live in {city}.");

//Exercise 3 – Application information
Console.WriteLine("");
Console.WriteLine("Application Information:");
Console.WriteLine($"Application Name: {Environment.GetEnvironmentVariable("APP_NAME")}");
Console.WriteLine($"Runtime Version: {Environment.GetEnvironmentVariable("RUNTIME_VERSION")}");
Console.WriteLine($"Machine Name: {Environment.MachineName}");
Console.WriteLine($"Operating System: {Environment.OSVersion}");
Console.WriteLine($"Framework Version: {Environment.Version}");
Console.WriteLine($"Current Date & Time: {DateTime.Now}");

