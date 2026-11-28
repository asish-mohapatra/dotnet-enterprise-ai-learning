using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeBonusEligibility.Models
{
    public class Employee
    {
        public string Name { get; set; }=string.Empty; //Stores the employee's name.
        public int Experience { get; set; }//Stores the total years of professional experience.
        public decimal PerformanceRating { get; set; }//Stores the employee's performance rating.
        public decimal AnnualSalary { get; set; }//Stores the employee's annual salary.
        public Enums.Department Department { get; set; }//Stores the employee's department using the enum.
    }
}
