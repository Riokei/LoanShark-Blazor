namespace LoanShark_Blazor.Data
{
    public class LoanPayment
    {
        public int Month { get; set; } = 0;
        public decimal Payment { get; set; } = 0;
        public decimal Principal { get; set; } = 0;
        public decimal Interest { get; set; } = 0; 
        public decimal TotalInterest { get; set; } = 0;
        public decimal Balance { get; set; }
    }
}
