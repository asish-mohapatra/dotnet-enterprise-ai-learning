using DotNetDay03.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetDay03.Services
{
    public class SalaryCalculator
    {
       public SalaryResult Calculate(
           decimal basicSalary,
           decimal hraPercentage,
           decimal specialAllowancePercentage,
           decimal professionalTaxPercentage,
           decimal otherDeductionPercentage,
           int performanceRating,
           bool isActive)
       {
           // Validate the basic salary and the 1-to-5 performance rating.
           if (basicSalary < 0m)
           {
               throw new ArgumentOutOfRangeException(nameof(basicSalary), "Basic salary cannot be negative.");
           }

           if (performanceRating < 1 || performanceRating > 5)
           {
               throw new ArgumentOutOfRangeException(nameof(performanceRating), "Performance rating must be between 1 and 5.");
           }

           // Validate each rate before using it in a calculation.
           ValidatePercentage(hraPercentage, nameof(hraPercentage));
           ValidatePercentage(specialAllowancePercentage, nameof(specialAllowancePercentage));
           ValidatePercentage(professionalTaxPercentage, nameof(professionalTaxPercentage));
           ValidatePercentage(otherDeductionPercentage, nameof(otherDeductionPercentage));

           // Basic salary must meet the threshold along with the rating and active-status requirements.
           bool bonusEligible = basicSalary >= 40000m && performanceRating >= 4 && isActive;
           decimal performanceBonus = bonusEligible ? basicSalary * 10m / 100m : 0m;

           // Calculate allowances from basic salary.
           decimal hra = basicSalary * hraPercentage / 100m;
           decimal specialAllowance = basicSalary * specialAllowancePercentage / 100m;

           // Gross salary is the amount earned before any deductions.
           decimal grossSalary = basicSalary + hra + specialAllowance + performanceBonus;

           // Apply professional tax to gross salary and the optional deduction to basic salary.
           decimal professionalTax = grossSalary * professionalTaxPercentage / 100m;
           decimal otherDeductions = basicSalary * otherDeductionPercentage / 100m;
           decimal totalDeductions = professionalTax + otherDeductions;
           decimal netSalary = grossSalary - totalDeductions;
           decimal totalDeductionPercentage = grossSalary == 0m
               ? 0m
               : totalDeductions / grossSalary * 100m;

           // Apply the illustrative payroll rounding policy to monetary values.
           return new SalaryResult
           {
               BasicSalary = RoundMoney(basicSalary),
               HRA = RoundMoney(hra),
               SpecialAllowance = RoundMoney(specialAllowance),
               PerformanceBonus = RoundMoney(performanceBonus),
               BonusEligible = bonusEligible,
               GrossSalary = RoundMoney(grossSalary),
               ProfessionalTax = RoundMoney(professionalTax),
               OtherDeductions = RoundMoney(otherDeductions),
               TotalDeductions = RoundMoney(totalDeductions),
               NetSalary = RoundMoney(netSalary),
               TotalAllowancePercentage = hraPercentage + specialAllowancePercentage,
               TotalDeductionPercentage = RoundMoney(totalDeductionPercentage)
           };
       }

        private static void ValidatePercentage(decimal percentage, string parameterName)
        {
            if (percentage < 0m || percentage > 100m)
            {
                throw new ArgumentOutOfRangeException(parameterName, "Percentage must be between 0 and 100.");
            }
        }

        private static decimal RoundMoney(decimal amount)
        {
            return Math.Round(amount, 2, MidpointRounding.AwayFromZero);
        }

    }
}
