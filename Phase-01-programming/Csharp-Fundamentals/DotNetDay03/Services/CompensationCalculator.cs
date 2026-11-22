using DotNetDay02.Configuration;
using DotNetDay02.Models;

namespace DotNetDay02.Services;

/// <summary>
/// Calculates illustrative annual compensation. This is not a statutory payroll engine.
/// </summary>
public static class CompensationCalculator
{
    public static decimal CalculateAnnualBaseSalary(Employee employee)
    {
        ArgumentNullException.ThrowIfNull(employee);

        if (employee.MonthlyBaseSalary < 0m)
        {
            throw new ArgumentOutOfRangeException(
                nameof(employee), "Monthly base salary cannot be negative.");
        }

        return employee.MonthlyBaseSalary * PayrollPolicy.MonthsPerYear;
    }

    public static decimal CalculateTargetAnnualBonus(Employee employee, decimal annualBaseSalary)
    {
        ArgumentNullException.ThrowIfNull(employee);

        if (employee.BonusPercentage < 0m)
        {
            throw new ArgumentOutOfRangeException(
                nameof(employee), "Bonus percentage cannot be negative.");
        }

        decimal bonusRate = employee.BonusPercentage / 100m;
        decimal unroundedBonus = annualBaseSalary * bonusRate;

        // The sample uses midpoint-to-even rounding. Production payroll must follow
        // the organization's approved accounting/payroll rounding policy.
        return decimal.Round(
            unroundedBonus,
            PayrollPolicy.CurrencyDecimalPlaces,
            MidpointRounding.ToEven);
    }

    public static decimal CalculateAnnualCompensation(
        decimal annualBaseSalary,
        decimal targetAnnualBonus)
    {
        return annualBaseSalary + targetAnnualBonus;
    }
}
