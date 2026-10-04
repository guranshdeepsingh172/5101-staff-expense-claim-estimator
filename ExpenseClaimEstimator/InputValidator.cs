namespace ExpenseClaimEstimator
{
    // Logic class: checks that inputs are valid before calculation (FR3).
    public class InputValidator
    {
        // Returns true if the expense is valid; otherwise sets 'message' with the reason.
        public bool IsValid(Expense expense, out string message)
        {
            message = "";

            if (string.IsNullOrWhiteSpace(expense.Category))
            {
                message = "Expense category is missing.";
                return false;
            }

            if (expense.Category == "Mileage")
            {
                // Business rule: kilometres must be greater than 0.
                if (expense.Kilometres <= 0)
                {
                    message = "Kilometres must be greater than 0 for a mileage claim.";
                    return false;
                }
            }
            else if (expense.Category == "Meal" || expense.Category == "Parking")
            {
                // Amount cannot be negative or missing.
                if (expense.Amount < 0)
                {
                    message = "Expense amount cannot be negative.";
                    return false;
                }
            }
            else
            {
                message = "Invalid expense category. Choose Mileage, Meal, or Parking.";
                return false;
            }

            return true;
        }
    }
}
