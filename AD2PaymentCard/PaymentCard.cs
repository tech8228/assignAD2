using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD2PaymentCard
{
    public class PaymentCard
    {
        private double balance;

        public PaymentCard(double openingBalance)
        {
            this.balance = openingBalance;
        }



        public override string ToString()
        {
            return ("The card has a balance of "+ balance +" euros");
            //return $"The card has a balance of {balance} euros";
        }
        
        public void EatLunch()
        {
            if (balance >= 10.60)
            {
                balance -= 10.60;
                
            }
        }

        public void DrinkCoffee()
        {
            balance -= 2.0;
        }

        public void AddMoney(double amount)
        {
            if(balance+amount >150 || amount < 0) 
            {  
                if (balance + amount > 150 )
                    {
                        balance = 150; 
                    }
                    
            } else 
            {
                balance += amount;
            }

           
        }

      
    }
}
