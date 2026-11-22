using System;
using System.Collections.Generic;
using System.Text;

namespace Day02Project.Configuration
{
    //Payroll constants and runtime configuration
    public class PayrollPolicy
    {
        public const int MonthsPerYear = 12;
        public const int CurrencyDecimalPlaces = 2;
        public const string CurrencyCode = "INR";
        private readonly DateTimeOffset _loadedAtUtc;
        public PayrollPolicy()
        {
            _loadedAtUtc = DateTimeOffset.UtcNow;
        }
        public DateTimeOffset LoadedAtUtc => _loadedAtUtc;
    }
}
