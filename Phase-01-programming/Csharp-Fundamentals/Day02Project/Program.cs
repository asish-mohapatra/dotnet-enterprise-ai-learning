using Day02Project.Configuration;
using Day02Project.Models;
using Day02Project.Services;
using System.Globalization;

// Select Indian number formatting.
CultureInfo indianCulture =
    CultureInfo.GetCultureInfo("en-IN");

// Create payroll policy.
var payrollPolicy = new PayrollPolicy();

// Create employee information.
var employee = new Employee
{
    EmployeeId = 1001,

    FullName = "Asha Sharma",

    Department = "Engineering",

    JoiningDate = new DateOnly(2022, 2, 15),

    MonthlyBaseSalary = 82_500.00m,

    BonusPercentage = 12.50m,

    IsActive = true,

    PerformanceGrade = 'A',

    ManagerName = "Priya Nair",

    YearsOfExperience = 8
};

// Example of nullable value type.
int? employeeBand = null;

// Calculate annual base salary.
decimal annualBaseSalary = CompensationCalculator.CalculateAnnualBaseSalary(employee);

// Calculate annual bonus.
decimal targetAnnualBonus = CompensationCalculator.CalculateTargetAnnualBonus(employee, annualBaseSalary);

// Calculate annual compensation.
decimal annualCompensation = CompensationCalculator.CalculateAnnualCompensation(annualBaseSalary, targetAnnualBonus);

// Prepare employee status.
string employmentStatus = employee.IsActive ? "Active" : "Inactive";

string managerDisplay = employee.ManagerName ?? "Not assigned";

string experienceDisplay = employee.YearsOfExperience is int years? $"{years} years" : "Not provided";

string bandDisplay = employeeBand?.ToString(indianCulture) ?? "Not assigned";

// Formatting helper.
static string FormatInr(decimal amount, CultureInfo culture)
{
    return $"{PayrollPolicy.CurrencyCode} " +  $"{amount.ToString("N2", culture)}";
}

// Display employee information.
Console.WriteLine("====================================================");

Console.WriteLine("             EMPLOYEE INFORMATION REPORT            ");

Console.WriteLine("====================================================");

Console.WriteLine($"Employee ID          : {employee.EmployeeId}");

Console.WriteLine($"Employee Name        : {employee.FullName}");

Console.WriteLine($"Department           : {employee.Department}");

Console.WriteLine($"Joining Date         : {employee.JoiningDate.ToString("dd-MMM-yyyy", indianCulture)}");

Console.WriteLine($"Employment Status    : {employmentStatus}");

Console.WriteLine($"Performance Grade    : {employee.PerformanceGrade}");

Console.WriteLine($"Reporting Manager    : {managerDisplay}");

Console.WriteLine($"Experience           : {experienceDisplay}");

Console.WriteLine($"Employee Band        : {bandDisplay}");

Console.WriteLine("----------------------------------------------------");

Console.WriteLine($"Monthly Base Salary  : {FormatInr(employee.MonthlyBaseSalary, indianCulture)}");

Console.WriteLine($"Annual Base Salary   : {FormatInr(annualBaseSalary, indianCulture)}");

Console.WriteLine($"Bonus Percentage     : {employee.BonusPercentage.ToString("N2", indianCulture)}%");

Console.WriteLine($"Target Annual Bonus  : {FormatInr(targetAnnualBonus, indianCulture)}");

Console.WriteLine($"Annual Compensation  : {FormatInr(annualCompensation, indianCulture)}");

Console.WriteLine("----------------------------------------------------");

Console.WriteLine($"Payroll policy loaded (UTC): {payrollPolicy.LoadedAtUtc:yyyy-MM-dd HH:mm:ss}");

Console.WriteLine("Note: This is an illustrative target-compensation estimate, not a payslip.");

Console.WriteLine("====================================================");