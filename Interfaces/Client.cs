using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    public class Client : IEnumerable<Deposit>
    {
        readonly Deposit[] deposits;

        public Client()
        {
            deposits = new Deposit[10];
        }

        public bool AddDeposit(Deposit deposit)
        {
            for (int i = 0; i < deposits.Length; i++)
            {
                if (deposits[i] == null)
                {
                    deposits[i] = deposit;
                    return true;
                }
            }
            return false;
        }

        public decimal TotalIncome()
        {
            decimal totalIncome = 0;
            foreach (var deposit in deposits)
            {
                if (deposit != null)
                {
                    totalIncome += deposit.Income();
                }
            }
            return totalIncome;
        }

        public decimal MaxIncome()
        {
            decimal maxIncome = 0;
            foreach (var deposit in deposits)
            {
                if (deposit != null && deposit.Income() > maxIncome)
                {
                    maxIncome = deposit.Income();
                }
            }
            return maxIncome;
        }

        public decimal GetIncomeByNumber(int number)
        {
            if (number <= 0 || number > deposits.Length || deposits[number - 1] == null)
            {
                return 0;
            }
            
            return deposits[number - 1].Income();
        }

        public void SortDeposits()
        {
            Array.Sort(deposits, (x, y) =>
            {
                if (x == null && y == null) return 0;
                if (x == null) return 1;
                if (y == null) return -1;
                decimal xTotalAmount = x.Amount + x.Income();
                decimal yTotalAmount = y.Amount + y.Income();
                return yTotalAmount.CompareTo(xTotalAmount); 
            });
        }

        public int CountPossibleToProlongDeposit()
        {
            return deposits.Count(deposit => deposit is IProlongable && ((IProlongable)deposit).CanToProlong());
        }
        public IEnumerator<Deposit> GetEnumerator()
        {
            return ((IEnumerable<Deposit>)deposits).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)deposits).GetEnumerator();
        }
    }

}