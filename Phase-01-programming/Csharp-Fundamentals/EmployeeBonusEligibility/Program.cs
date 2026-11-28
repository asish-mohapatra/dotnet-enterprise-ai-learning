using System.Globalization;
using EmployeeBonusEligibility.Enums;
using EmployeeBonusEligibility.Models;
using EmployeeBonusEligibility.Services;

Console.OutputEncoding = System.Text.Encoding.UTF8;
CultureInfo indianCulture = CultureInfo.GetCultureInfo("en-IN");

Console.WriteLine("==================================");
Console.WriteLine("   EMPLOYEE BONUS ELIGIBILITY");
Console.WriteLine("==================================");

Console.Write("Enter employee name: ");
string name = Console.ReadLine()?.Trim() ?? string.Empty;

if (string.IsNullOrWhiteSpace(name))
{
    Console.WriteLine("Invalid employee name.");
    return;
}

Console.Write("Enter years of experience: ");

if (!int.TryParse(Console.ReadLine(), out int experience) || experience < 0 || experience > 50)
{
    Console.WriteLine("Invalid experience. Enter 0 to 50.");
    return;
}

Console.Write("Enter performance rating (1-5): ");

if (!decimal.TryParse(Console.ReadLine(), out decimal rating) || rating < 1m || rating > 5m)
{
    Console.WriteLine("Invalid performance rating.");
    return;
}

Console.Write("Enter annual salary: ");

if (!decimal.TryParse(Console.ReadLine(), out decimal salary) || salary <= 0m)
{
    Console.WriteLine("Invalid annual salary.");
    return;
}

Console.Write("Enter department: ");

string departmentInput = Console.ReadLine()?.Trim() ?? string.Empty;

if (!Enum.TryParse<Department>(departmentInput, ignoreCase: true, out Department department) || !Enum.IsDefined(typeof(Department), department))
{
    Console.WriteLine("Invalid department.");
    return;
}

// Create employee object.
Employee employee = new()
{
    Name = name,
    Experience = experience,
    PerformanceRating = rating,
    AnnualSalary = salary,
    Department = department
};

// Create bonus policy service.
BonusPolicy policy = new();

// Calculate grade.
string grade = policy.GetGradeUsingIfElse(rating);

// Calculate bonus percentage.
decimal bonusPercentage = policy.GetBonusPercentage(grade);

// Calculate bonus.
decimal bonus = policy.CalculateBonus(salary, bonusPercentage);

// Evaluate eligibility.
bool isEligible = policy.IsEligibleForBonus(employee);

// Display results.
Console.WriteLine();
Console.WriteLine("========== BONUS RESULT ==========");

Console.WriteLine($"Employee Name       : {employee.Name}");
Console.WriteLine($"Department          : {employee.Department}");
Console.WriteLine($"Experience          : {employee.Experience}");
Console.WriteLine($"Performance Rating  : {employee.PerformanceRating}");
Console.WriteLine($"Employee Grade      : {grade}");
Console.WriteLine($"Eligibility         : {policy.GetFinalDecision(employee)}");

if (isEligible)
{
    Console.WriteLine($"Bonus Percentage    : {bonusPercentage:P0}");
    Console.WriteLine($"Bonus Amount        : {bonus.ToString("C", indianCulture)}");

    Console.WriteLine($"Approval            : {policy.GetApprovalMessage(department)}");
}
else
{
    Console.WriteLine($"Bonus Amount        : {0m.ToString("C", indianCulture)}");
}

Console.WriteLine("==================================");