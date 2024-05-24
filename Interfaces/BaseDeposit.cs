using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public class BaseDeposit : Deposit
    {
        public BaseDeposit(decimal depositAmount, int depositPeriod)
            : base(depositAmount, depositPeriod)
        {
        }

        public override decimal Income()
        {
            decimal currentAmount = Amount;
            decimal totalIncome = 0;

            for (int month = 1; month <= Period; month++)
            {
                decimal monthlyIncome = currentAmount * 0.05m;
                totalIncome += monthlyIncome;

                currentAmount += monthlyIncome;

                currentAmount = Math.Round(currentAmount, 2);
                totalIncome = Math.Round(totalIncome, 2);
            }

            return totalIncome;
        }
    }
}