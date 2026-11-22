using System;
using System.Collections.Generic;
using System.Text;

namespace Day02Project.Models
{
    /// <summary>
    /// Represents an employee and their employment and performance details.
    /// </summary>
    //Employee Data Reperesntation
    public class Employee
    {
        public int EmployeeId { get; init; }//Numeric employee identifier

        public string FullName { get; init; } = string.Empty;//Employee name

        public string Department { get; init; } = string.Empty;//Department name

        public DateOnly JoiningDate { get; init; }//Calendar date without a time component

        public decimal MonthlyBaseSalary { get; init; }//Financial calculation

        public decimal BonusPercentage { get; init; }//Accurate decimal-based percentage calculation

        public bool IsActive { get; init; }//Active or inactive status

        public char PerformanceGrade { get; init; }//Single-character grade

        public string? ManagerName { get; init; }//Manager might not yet be assigned

        public int? YearsOfExperience { get; init; }//Information might not yet be available

    }
}
