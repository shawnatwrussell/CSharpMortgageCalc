using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MortgageCalc.Models
{
    public class Loan
    {
        //INPUT FROM USER
        public decimal Amount { get; set; }
        public double Rate { get; set; }
        public int Term { get; set; }

        //WHAT TO DISPLAY
        public decimal Payment { get; set; }
        public decimal TotalInterest { get; set; }
        public decimal TotalCost { get; set; }

        public List<LoanPayment> Payments { get; set; } = new List<Models.LoanPayment>();
       
    }
}
