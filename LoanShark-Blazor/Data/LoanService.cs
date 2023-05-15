namespace LoanShark_Blazor.Data
{
    public class LoanService
    {
        //Calculate Montly Payment
        public Loan GetPayments(Loan loan)
        {
            //Call the MontlyPayment function and set the amount/rate/term            
            loan.Payment = CalcMonthlyPayment(loan.Amount, loan.Rate, loan.Term);
            //Set up some variables
            decimal balance = loan.Amount;
            decimal totalInterest = 0.0m;
            decimal monthlyRate = CalcRate(loan.Rate);

           

            //For look time to do the math and push it into the array.
            for (int month = 1; month <= loan.Term; month++ )
            {
                //Calculate the monthly interest.
                decimal monthlyInterest = CalcInterest(balance, monthlyRate);
                //Add the monthly interest to the total interest counter outside of the loop.
                totalInterest += monthlyInterest;
                //Calculate the monthlyPrincipal
                decimal monthlyPrincipal = loan.Payment - monthlyInterest;
                //Subtract from the balance
                balance -= monthlyPrincipal;
                //Create  a new loan table.
                LoanPayment loanPayment = new();
                //Set variables
                loanPayment.Month = month;
                loanPayment.Payment = loan.Payment;
                loanPayment.Principal = monthlyPrincipal;
                loanPayment.Interest = monthlyInterest;
                loanPayment.TotalInterest = totalInterest;
                loanPayment.Balance = balance;

                //Add these to the table.
                loan.loanPayments.Add(loanPayment);
            }
            loan.TotalRate = totalInterest;
            loan.TotalAmount = loan.Amount + totalInterest;
            return loan;
        }

        //Calculate minor stuff outside of this
        //first the payment, then the rate, then the interest.
        private static decimal CalcMonthlyPayment (decimal amount, decimal rate, int term)
        {
            decimal monthlyRate = CalcRate(rate);
            double rateD = Convert.ToDouble(monthlyRate);
            double amountD = Convert.ToDouble(amount);

            double payment = (amountD * rateD) / (1 - Math.Pow(1 + rateD, -term));
            return Convert.ToDecimal (payment);
        }
        private static decimal CalcRate (decimal rate)
        {
            return rate / 1200;
        }
        private static decimal CalcInterest (decimal balance, decimal rate) 
        {
            return (balance * rate);
        }
    }
}
