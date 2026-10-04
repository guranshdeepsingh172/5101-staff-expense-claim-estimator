namespace ExpenseClaimEstimator
{
    // Model class: holds the data for one expense entry (FR1).
    public class Expense
    {
        public string StaffName { get; set; }
        public string ExpenseDate { get; set; }
        public string Category { get; set; }   // "Mileage", "Meal", or "Parking"
        public double Kilometres { get; set; }  // used only for Mileage
        public decimal Amount { get; set; }     // used only for Meal / Parking
        public string Description { get; set; }
    }
}
