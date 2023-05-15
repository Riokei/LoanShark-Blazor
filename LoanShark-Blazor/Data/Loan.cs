namespace LoanShark_Blazor.Data
{
    public class Loan
    {
        public decimal Amount { get; set; } = 0;
        public decimal Rate { get; set; } = 0;
        public int Term { get; set; } = 0;
        public decimal Payment { get; set; } = 0;
        public decimal TotalAmount { get; set; } = 0;
        public decimal TotalRate { get; set; } = 0;
        public List<LoanPayment> loanPayments { get; set; } = new List<LoanPayment>();
    }
}
