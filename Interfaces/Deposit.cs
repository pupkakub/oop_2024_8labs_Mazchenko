using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public abstract class Deposit : IComparable<Deposit>
    {
        public decimal Amount { get; }
        public int Period { get; }

        protected Deposit(decimal depositAmount, int depositPeriod)
        {
            Amount = depositAmount;
            Period = depositPeriod;
        }

        public abstract decimal Income();
        public int CompareTo(Deposit other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other), "The 'other' parameter cannot be null.");
            }

            decimal thisTotalAmount = Amount + Income();
            decimal otherTotalAmount = other.Amount + other.Income();

            if (thisTotalAmount < otherTotalAmount)
                return -1;
            else if (thisTotalAmount > otherTotalAmount)
                return 1;
            else
                return 0;
        }
        public static bool operator ==(Deposit left, Deposit right)
        {
            if (ReferenceEquals(left, right))
            {
                return true;
            }
            if (left is null || right is null)
            {
                return false;
            }
            return left.CompareTo(right) == 0;
        }

        public static bool operator !=(Deposit left, Deposit right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is Deposit other)
            {
                return this.Amount == other.Amount && this.Period == other.Period;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Amount, Period);
        }

    }
}
