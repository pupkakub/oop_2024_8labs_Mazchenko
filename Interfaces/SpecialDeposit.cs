using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public class SpecialDeposit : Deposit, IProlongable
    {
        public SpecialDeposit(decimal depositAmount, int depositPeriod)
            : base(depositAmount, depositPeriod)
        {
        }

        public override decimal Income()
        {
            decimal currentAmount = Amount;
            decimal totalIncome = 0;

            for (int month = 1; month <= Period; month++)
            {
                decimal monthlyIncome = currentAmount * ((decimal)month / 100);
                totalIncome += monthlyIncome;

                currentAmount += monthlyIncome;
            }

            return totalIncome;
        }
        public bool CanToProlong()
        {
            const decimal minimumAmount = 1000;
            return Amount > minimumAmount;
        }
    }
}
