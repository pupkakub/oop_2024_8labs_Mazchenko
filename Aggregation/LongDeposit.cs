namespace Aggregation
{
    public class LongDeposit : Deposit
    {
        public LongDeposit(decimal depositAmount, int depositPeriod)
            : base(depositAmount, depositPeriod)
        {
        }

        public override decimal Income()
        {
            decimal currentAmount = Amount; 
            decimal totalIncome = 0;

            for (int month = 1; month <= Period; month++)
            {
                if (month >= 7)
                {
                    decimal monthlyIncome = currentAmount * 0.15m;
                    totalIncome += monthlyIncome; 
                    currentAmount += monthlyIncome; 
                }
            }

            return totalIncome;
        }
    }
}