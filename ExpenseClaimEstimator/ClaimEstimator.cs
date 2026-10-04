namespace ExpenseClaimEstimator
{
    // Logic class: applies the business rules.
    // Feature A - Business-Rule Calculation (FR4)
    // Feature B - Cap and Notify (FR5)
    public class ClaimEstimator
    {
        // Policy values (teaching case only) - held as named constants.
        private const decimal MILEAGE_RATE = 0.85m;
        private const decimal MEAL_CAP = 35.00m;
        private const decimal PARKING_CAP = 40.00m;

        // Calculates the reimbursable amount and returns a message about any capping.
        public decimal Estimate(Expense expense, out string message)
        {
            decimal rawAmount = 0m;
            message = "";

            // ---- Feature A: calculate the raw amount per category ----
            switch (expense.Category)
            {
                case "Mileage":
                    rawAmount = (decimal)expense.Kilometres * MILEAGE_RATE;
                    message = "Amount is within the allowed limit.";
                    return rawAmount;   // mileage has no cap

                case "Meal":
                    rawAmount = expense.Amount;
                    return ApplyCap(rawAmount, MEAL_CAP, out message);

                case "Parking":
                    rawAmount = expense.Amount;
                    return ApplyCap(rawAmount, PARKING_CAP, out message);

                default:
                    message = "Invalid expense category.";
                    return 0m;
            }
        }

        // ---- Feature B: cap the amount to the limit and notify ----
        private decimal ApplyCap(decimal amount, decimal cap, out string message)
        {
            if (amount > cap)
            {
                message = $"Amount exceeded the limit and was capped to ${cap:0.00}.";
                return cap;
            }

            message = "Amount is within the allowed limit.";
            return amount;
        }
    }
}
