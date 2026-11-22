using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetDay03.Models
{
    public class SalaryResult
    {
        public decimal BasicSalary { get; set; }
        public decimal HRA { get; set; }
        public decimal SpecialAllowance { get; set; }
        public decimal PerformanceBonus { get; set; }
        public bool BonusEligible { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal ProfessionalTax { get; set; }
        public decimal OtherDeductions { get; set; }
        public decimal TotalDeductions { get; set; }
        public decimal NetSalary { get; set; }
        public decimal TotalAllowancePercentage { get; set; }
        public decimal TotalDeductionPercentage { get; set; }

    }
}
