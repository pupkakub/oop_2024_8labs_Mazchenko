using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceTask
{
        public class Manager : Employee
        {
            private readonly int quantity;

            public Manager(string name, decimal salary, int clientAmount) : base(name, salary)
            {
                quantity = clientAmount;
            }

            public override void SetBonus(decimal bonus)
            {
                decimal managerBonus = bonus;
                if (quantity > 150)
                {
                    managerBonus += 1000;
                }
                else if (quantity > 100)
                {
                    managerBonus += 500;
                }

                base.SetBonus(managerBonus);
            }
        }
    
}


