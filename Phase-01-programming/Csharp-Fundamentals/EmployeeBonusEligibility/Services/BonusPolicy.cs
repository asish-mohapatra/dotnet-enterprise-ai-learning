using EmployeeBonusEligibility.Enums;
using EmployeeBonusEligibility.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeBonusEligibility.Services
{
    public class BonusPolicy
    {
        // Minimum requirements for bonus eligibility.
        private const int MinimumExperience = 2; // Minimum years of experience required for bonus eligibility.
        private const decimal MinimumPerformanceRating = 4.0m; // Minimum performance rating required for bonus eligibility.
        // 1. Employee grade classification using if-else.
        public string GetGradeUsingIfElse(decimal rating)
        {
            if(rating >= 4.5m)
            {
                return "A";
            }
            else if (rating >= 4.0m)
            {
                return "B";
            }
            else if (rating >= 3.0m)
            {
                return "C";
            }
            else
            {
                return "D";
            }
        }

        // 2. The same grade classification using a switch expression.
        public string GetGradeUsingSwitchExpression(decimal rating)
        {
            return rating switch
            {
                >= 4.5m => "A",
                >= 4.0m => "B",
                >= 3.0m => "C",
                _ => "D"
            };
        }

        // 3. Evaluate mandatory eligibility requirements.
        public bool IsEligibleForBonus(Employee employee)
        {
            return employee.Experience >= MinimumExperience && employee.PerformanceRating >= MinimumPerformanceRating && employee.Department != Enums.Department.HumanResources;
        }

        // 4. Calculate bonus percentage using a switch expression.
        public decimal GetBonusPercentage(string grade)
        {
            return grade switch
            {
                "A" => 0.20m,
                "B" => 0.15m,
                "C" => 0.10m,
                _ => 0m // Default bonus percentage for other Grades.
            };
        }

        // 5. Calculate the bonus amount.
        public decimal CalculateBonus(decimal annualSalary, decimal bonusPercentage)
        {
            return annualSalary * bonusPercentage;
        }

        // 6. Department-specific approval requirements.
        public string GetApprovalMessage(Enums.Department department)
        {
            return department switch
            {
                Department.Finance => "Finance manager approval required.",
                Department.Engineering => "Normal approval required.",
                Department.Sales => "normal approval required.",
                Department.Operations => "Normal approval required.",
                Department.HumanResources => "HR employees are excluded.",
                _ => "Unknown department."
            };
        }

        // 7. Produce the final decision.
        public string GetFinalDecision(Employee employee)
        {
            if (!IsEligibleForBonus(employee))
            {
                if( employee.Experience < MinimumExperience)
                {
                    return $"Employee {employee.Name} is not eligible for a bonus due to insufficient experience.";
                }
                else if (employee.PerformanceRating < MinimumPerformanceRating)
                {
                    return $"Employee {employee.Name} is not eligible for a bonus due to low performance rating.";
                }
                else if (employee.Department == Enums.Department.HumanResources)
                {
                    return $"Employee {employee.Name} is not eligible for a bonus as they belong to the Human Resources department.";
                }
                else
                {
                    return $"Employee {employee.Name} is not eligible for a bonus.";
                }
            }
            return "Eligible for bonus.";
        }
    }
}
