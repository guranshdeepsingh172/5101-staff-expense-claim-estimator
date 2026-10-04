using System;

namespace ExpenseClaimEstimator
{
    // Console driver: handles inputs and outputs for the proof-of-concept.
    // (Takes the role of the interface/ExpenseForm from Task 2.)
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Staff Expense Claim Estimator (Proof-of-Concept) ===");
            Console.WriteLine();

            // ---- INPUT (FR1, FR2) ----
            Console.Write("Staff name: ");
            string name = Console.ReadLine();

            Console.Write("Expense date (dd/mm/yyyy): ");
            string date = Console.ReadLine();

            Console.Write("Category (Mileage / Meal / Parking): ");
            string category = Console.ReadLine();

            var expense = new Expense
            {
                StaffName = name,
                ExpenseDate = date,
                Category = category
            };

            if (category == "Mileage")
            {
                Console.Write("Kilometres travelled: ");
                double.TryParse(Console.ReadLine(), out double km);
                expense.Kilometres = km;
            }
            else
            {
                Console.Write("Expense amount ($): ");
                decimal.TryParse(Console.ReadLine(), out decimal amount);
                expense.Amount = amount;
            }

            Console.Write("Description: ");
            expense.Description = Console.ReadLine();

            // ---- PROCESSING / DECISIONS (FR3, FR4, FR5) ----
            var validator = new InputValidator();
            var estimator = new ClaimEstimator();

            if (!validator.IsValid(expense, out string validationMessage))
            {
                Console.WriteLine();
                Console.WriteLine("ERROR: " + validationMessage);
                return;
            }

            decimal reimbursable = estimator.Estimate(expense, out string resultMessage);

            // ---- OUTPUT (FR6) ----
            Console.WriteLine();
            Console.WriteLine("---------- CLAIM SUMMARY ----------");
            Console.WriteLine($"Staff name:      {expense.StaffName}");
            Console.WriteLine($"Date:            {expense.ExpenseDate}");
            Console.WriteLine($"Category:        {expense.Category}");
            Console.WriteLine($"Description:     {expense.Description}");
            Console.WriteLine($"Estimated reimbursable amount: ${reimbursable:0.00}");
            Console.WriteLine($"Message:         {resultMessage}");
            Console.WriteLine("-----------------------------------");
        }
    }
}
