using Day02Project.Configuration;
using Day02Project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Day02Project.Services
{
    //	Payroll calculation logic
    public class CompensationCalculator
    {
        public static decimal CalculateAnnualBaseSalary(Employee employee)
        {
            ArgumentNullException.ThrowIfNull(employee);

            if (employee.MonthlyBaseSalary < 0m)
            {
                throw new ArgumentOutOfRangeException(nameof(employee), "Monthly base salary cannot be negative.");
            }

            return employee.MonthlyBaseSalary * PayrollPolicy.MonthsPerYear;
        }

        public static decimal CalculateTargetAnnualBonus(Employee employee, decimal annualBaseSalary)
        {
            ArgumentNullException.ThrowIfNull(employee);

            if (employee.BonusPercentage < 0m)
            {
                throw new ArgumentOutOfRangeException(nameof(employee), "Bonus percentage cannot be negative.");
            }

            decimal bonusRate = employee.BonusPercentage / 100m;

            decimal unroundedBonus = annualBaseSalary * bonusRate;

            return decimal.Round(unroundedBonus, PayrollPolicy.CurrencyDecimalPlaces, MidpointRounding.ToEven);
        }

        public static decimal CalculateAnnualCompensation(decimal annualBaseSalary, decimal targetAnnualBonus)
        {
            return annualBaseSalary + targetAnnualBonus;
        }
    }
}
