using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public class LongDeposit : Deposit, IProlongable
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
                if (month >= 7 && month <= Period) 
                {
                    decimal monthlyIncome = currentAmount * 0.15m;
                    totalIncome += monthlyIncome;
                    currentAmount += monthlyIncome;
                }
            }

            return totalIncome;
        }
        public bool CanToProlong()
        {
            const int maximumTermInMonths = 3 * 12;
            return Period <= maximumTermInMonths;
        }
    }
}
