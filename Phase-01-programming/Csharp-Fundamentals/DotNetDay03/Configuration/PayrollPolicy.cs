namespace DotNetDay02.Configuration;

/// <summary>
/// Contains payroll constants and a value captured when the policy object is created.
/// </summary>
public sealed class PayrollPolicy
{
    // Compile-time values: these are suitable for const.
    public const int MonthsPerYear = 12;
    public const int CurrencyDecimalPlaces = 2;
    public const string CurrencyCode = "INR";

    // Runtime value: readonly can be assigned in the constructor.
    private readonly DateTimeOffset _loadedAtUtc;

    public PayrollPolicy()
    {
        _loadedAtUtc = DateTimeOffset.UtcNow;
    }

    public DateTimeOffset LoadedAtUtc => _loadedAtUtc;
}
