namespace DotNetDay02.Models;

/// <summary>
/// Represents the employee information needed by this learning application.
/// </summary>
public sealed class Employee
{
    public int EmployeeId { get; init; }

    public string FullName { get; init; } = string.Empty;

    public string Department { get; init; } = string.Empty;

    public DateOnly JoiningDate { get; init; }

    public decimal MonthlyBaseSalary { get; init; }

    /// <summary>
    /// Percentage expressed as a human percentage, for example 12.5 means 12.5%.
    /// </summary>
    public decimal BonusPercentage { get; init; }

    public bool IsActive { get; init; }

    public char PerformanceGrade { get; init; }

    // These details may not be known when an employee record is first created.
    public string? ManagerName { get; init; }

    public int? YearsOfExperience { get; init; }
}
