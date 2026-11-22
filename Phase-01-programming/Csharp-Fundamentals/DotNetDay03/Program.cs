using DotNetDay03.Models;
using DotNetDay03.Services;
using System.Globalization;

internal class Program
{
    private static readonly CultureInfo InputCulture = CultureInfo.InvariantCulture;

    private static readonly CultureInfo DisplayCulture = CultureInfo.GetCultureInfo("en-IN");

    private static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("==================================================");
        Console.WriteLine("                SALARY CALCULATOR                 ");
        Console.WriteLine("==================================================");

        try
        {
            string employeeName = ReadEmployeeName();
            int employeeId = ReadEmployeeId();
            decimal annualSalary = ReadAnnualSalary();
            int monthlyEmployeeCount = ReadMonthlyEmployeeCount();

            // Validate the count before division and check integral employee-month arithmetic.
            int employeeMonths = checked(monthlyEmployeeCount * 12);
            decimal averageMonthlySalary = annualSalary / employeeMonths;

            decimal basicSalary = ReadDecimal("Enter Basic Salary: ", minimum: 0m);
            int performanceRating = ReadPerformanceRating();
            bool isActive = ReadYesNo("Is the employee active? (y/n): ");
            decimal hraPercentage = ReadPercentage("Enter HRA Percentage: ");
            decimal specialAllowancePercentage = ReadPercentage("Enter Special Allowance Percentage: ");
            decimal professionalTaxPercentage = ReadPercentage("Enter Professional Tax Percentage: ");

            // The optional deduction is omitted by entering no; its percentage is then zero.
            decimal otherDeductionPercentage = ReadYesNo("Apply an optional other deduction? (y/n): ")
                ? ReadPercentage("Enter Other Deduction Percentage: ")
                : 0m;

            SalaryCalculator calculator = new();
            SalaryResult result = calculator.Calculate(
                basicSalary,
                hraPercentage,
                specialAllowancePercentage,
                professionalTaxPercentage,
                otherDeductionPercentage,
                performanceRating,
                isActive);

            DisplayResult(
                employeeName,
                employeeId,
                annualSalary,
                monthlyEmployeeCount,
                averageMonthlySalary,
                performanceRating,
                isActive,
                result);
        }
        catch (OverflowException)
        {
            Console.WriteLine("Calculation failed: Numeric overflow detected.");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Validation Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected application error: {ex.Message}");
        }

        Console.WriteLine();
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();

    }
    private static string ReadEmployeeName()
    {
        while (true)
        {
            Console.Write("Enter Employee Name: ");
            string? name = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(name))
            {
                return name.Trim();
            }

            Console.WriteLine("Employee name cannot be empty.");
        }
    }

    private static int ReadEmployeeId()
    {
        while (true)
        {
            Console.Write("Enter Employee ID: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, NumberStyles.Integer, InputCulture, out int employeeId) && employeeId > 0)
            {
                return employeeId;
            }

            Console.WriteLine("Enter a valid positive whole-number employee ID.");
        }
    }

    private static decimal ReadAnnualSalary()
    {
        while (true)
        {
            Console.Write("Enter Annual Salary: ");
            string? input = Console.ReadLine();

            if (decimal.TryParse(input, NumberStyles.Number, InputCulture, out decimal annualSalary)
                && annualSalary >= 0m)
            {
                return annualSalary;
            }

            Console.WriteLine("Enter a valid non-negative annual salary within the supported decimal range.");
        }
    }

    private static int ReadMonthlyEmployeeCount()
    {
        while (true)
        {
            Console.Write("Enter Monthly Employee Count: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, NumberStyles.Integer, InputCulture, out int employeeCount)
                && employeeCount > 0)
            {
                return employeeCount;
            }

            Console.WriteLine("Employee count must be a positive whole number.");
        }
    }

    private static int ReadPerformanceRating()
    {
        while (true)
        {
            Console.Write("Enter Performance Rating (1-5): ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, NumberStyles.Integer, InputCulture, out int rating)
                && rating >= 1
                && rating <= 5)
            {
                return rating;
            }

            Console.WriteLine("Performance rating must be a whole number between 1 and 5.");
        }
    }

    private static bool ReadYesNo(string message)
    {
        while (true)
        {
            Console.Write(message);
            string? input = Console.ReadLine()?.Trim();

            if (string.Equals(input, "y", StringComparison.OrdinalIgnoreCase)
                || string.Equals(input, "yes", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (string.Equals(input, "n", StringComparison.OrdinalIgnoreCase)
                || string.Equals(input, "no", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            Console.WriteLine("Enter y or n.");
        }
    }

    private static decimal ReadDecimal(string message, decimal minimum)
    {
        while (true)
        {
            Console.Write(message);

            string? input = Console.ReadLine();

            if (decimal.TryParse(input, NumberStyles.Number, InputCulture, out decimal value))
            {
                if (value >= minimum)
                {
                    return value;
                }

                Console.WriteLine($"Value must be at least {minimum}.");
            }
            else
            {
                Console.WriteLine("Invalid input. Enter a valid numeric value.");
            }
        }
    }

    private static decimal ReadPercentage(string message)
    {
        while (true)
        {
            decimal value = ReadDecimal(message, 0m);

            if (value <= 100m)
            {
                return value;
            }

            Console.WriteLine("Percentage must not exceed 100.");
        }
    }

    private static void DisplayResult(
        string employeeName,
        int employeeId,
        decimal annualSalary,
        int monthlyEmployeeCount,
        decimal averageMonthlySalary,
        int performanceRating,
        bool isActive,
        SalaryResult result)
    {
        string bonusEligibility = result.BonusEligible ? "Qualifies" : "Does not qualify";

        Console.WriteLine();
        Console.WriteLine("==================================================");
        Console.WriteLine("                  PAYROLL SUMMARY                 ");
        Console.WriteLine("==================================================");
        Console.WriteLine($"Employee Name               : {employeeName}");
        Console.WriteLine($"Employee ID                 : {employeeId}");
        Console.WriteLine($"Annual Salary               : {annualSalary.ToString("C2", DisplayCulture)}");
        Console.WriteLine($"Monthly Employee Count      : {monthlyEmployeeCount}");
        Console.WriteLine($"Average Monthly Salary      : {averageMonthlySalary.ToString("C2", DisplayCulture)}");
        Console.WriteLine($"Performance Rating          : {performanceRating}");
        Console.WriteLine($"Active Employee             : {(isActive ? "Yes" : "No")}");
        Console.WriteLine($"Bonus Eligibility           : {bonusEligibility}");
        Console.WriteLine($"Basic Salary                : {result.BasicSalary.ToString("C2", DisplayCulture)}");
        Console.WriteLine($"HRA                         : {result.HRA.ToString("C2", DisplayCulture)}");
        Console.WriteLine($"Special Allowance           : {result.SpecialAllowance.ToString("C2", DisplayCulture)}");
        Console.WriteLine($"Performance Bonus           : {result.PerformanceBonus.ToString("C2", DisplayCulture)}");
        Console.WriteLine($"Total Allowance Percentage  : {result.TotalAllowancePercentage.ToString("0.##", DisplayCulture)}%");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine($"Salary Before Deductions    : {result.GrossSalary.ToString("C2", DisplayCulture)}");
        Console.WriteLine($"Professional Tax            : {result.ProfessionalTax.ToString("C2", DisplayCulture)}");
        Console.WriteLine($"Other Deductions            : {result.OtherDeductions.ToString("C2", DisplayCulture)}");
        Console.WriteLine($"Total Deductions            : {result.TotalDeductions.ToString("C2", DisplayCulture)}");
        Console.WriteLine($"Total Deduction Percentage  : {result.TotalDeductionPercentage.ToString("0.##", DisplayCulture)}%");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine($"Salary After Deductions     : {result.NetSalary.ToString("C2", DisplayCulture)}");
        Console.WriteLine("==================================================");
    }
}