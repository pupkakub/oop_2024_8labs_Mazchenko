using System;
using System.Linq;

namespace InheritanceTask
{
    public class Company 
    {
        readonly Employee[] employees;

        public Company(Employee[] employees)
        {
            if (employees == null || employees.Length == 0)
            {
                throw new ArgumentException("Employees array cannot be null or empty.", nameof(employees));
            }

            this.employees = employees;
        }
    
        
        public void GiveEverybodyBonus(decimal companyBonus)
        {
            if (companyBonus < 0)
            {
                throw new ArgumentException("Company bonus should be greater than zero.", nameof(companyBonus));
            }

            foreach (Employee employee in employees)
            {
                employee.SetBonus(companyBonus);
            }
        }
        
        public decimal TotalToPay()
        {
            decimal totalPayment = 0;
            foreach (Employee employee in employees)
            {
                totalPayment += employee.ToPay();
            }
            return totalPayment;
        }
        
        public string NameMaxSalary()
        {
            if (employees.Length == 0)
            {
                throw new InvalidOperationException("Cannot determine max salary name. Employees array is empty.");
            }
            Employee topEarner = employees.OrderByDescending(e => e.ToPay()).FirstOrDefault();
            string name = topEarner?.Name;
            if (name != null)
            {
                string[] parts = name.Split(' ');
                if (parts.Length > 0)
                {
                    return parts[parts.Length - 1]; 
                }
            }

            return "";
        }
    }
}
