# Salary Calculator Requirements

## 1. Purpose

The application is a console-based learning example that collects employee and payroll information, calculates salary components, and displays a payroll summary. It is illustrative and is not a statutory payroll system.

## 2. Functional requirements

### 2.1 Employee information

- Prompt for the employee's name and require a non-empty value. Trim surrounding whitespace.
- Prompt for a positive whole-number employee ID.
- Prompt for the employee's performance rating as a whole number from 1 through 5.
- Prompt whether the employee is active, accepting `y`/`yes` or `n`/`no` regardless of letter case.

### 2.2 Annual payroll and average monthly salary

- Prompt for a non-negative annual salary using `decimal.TryParse`.
- Prompt for a positive whole-number monthly employee count.
- Calculate the average monthly salary per employee from the entered annual payroll amount and employee count:

  `average monthly salary = annual salary / (monthly employee count * 12)`

- Validate that employee count is positive before division. Calculate employee-months using checked integral arithmetic so an overflow is detected rather than wrapped.

### 2.3 Salary calculation inputs

- Prompt for non-negative basic salary.
- Prompt for HRA, special allowance, and professional tax percentages, each from 0% through 100%.
- Ask whether to apply an optional other deduction. If selected, prompt for a deduction percentage from 0% through 100%; otherwise use 0%.

### 2.4 Bonus eligibility and calculation

- An employee qualifies for a performance bonus only when all of the following are true:
  - Basic salary is at least ₹40,000.
  - Performance rating is at least 4.
  - The employee is active.
- Evaluate eligibility using relational operators combined with logical AND.
- Calculate the bonus as 10% of basic salary when eligible; otherwise the bonus is ₹0. The calculation uses `decimal` and a ternary operator.

### 2.5 Payroll calculations and summary

- Calculate HRA and special allowance as percentages of basic salary.
- Calculate gross salary before deductions as basic salary plus HRA, special allowance, and any bonus.
- Calculate professional tax as a percentage of gross salary. Calculate the optional other deduction as a percentage of basic salary.
- Display employee identity, annual payroll inputs, average monthly salary, bonus eligibility, salary components, total allowance percentage, total deductions and their percentage, salary before deductions, and salary after deductions.
- Round displayed monetary calculation results to two decimal places using midpoint rounding away from zero.

## 3. Validation and error handling

- Re-prompt on malformed, out-of-range, or missing interactive inputs, with an explanatory validation message.
- Reject negative salaries, non-positive employee counts and IDs, invalid performance ratings, percentages outside 0-100%, and invalid yes/no answers.
- Handle arithmetic overflow with an explicit error message. Do not silently continue with a wrapped or invalid result.
- Use `decimal` for salary, bonus, and payroll percentage calculations; use checked arithmetic for integral employee-month calculation.

## 4. Calculation assumptions

- The annual salary entered for the average calculation represents the total annual payroll amount for the monthly employee count, not the individual employee's basic salary.
- The monthly employee count is treated as constant for all 12 months in the annual averaging calculation.
- Basic salary for the bonus threshold and salary breakdown is entered separately from the annual payroll amount.
- Bonus eligibility depends on basic salary, not annual payroll amount or calculated gross salary.
- Total allowance percentage is the sum of HRA and special allowance percentages. The performance bonus is presented separately and is not counted as an allowance percentage.
- Total deduction percentage is total deductions divided by gross salary; it is 0% when gross salary is zero.

## 5. Runtime

- Application type: .NET console application.
- Target framework: .NET 11 (`net11.0`).
