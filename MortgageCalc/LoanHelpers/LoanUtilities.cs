using MortgageCalc.Models;
using System;
using System.Collections.Generic;
using static MortgageCalc.Models.Loan;

namespace MortgageCalc.LoanHelpers
{
    public class LoanUtilities
    {
        //Method declaration is four parts
        //access modifier - public or private for right now
        //return type - what the method spits out
        //method name - PascalCaseYourMethodNames
        //parameters - wrapped in ( ) every parameter needs a Type (decimal, int, string Loan) and a name (amount, term, loan)
        //Then you put { } around the code it runs just like JavaScript
        //overloading - you can have multiple methods with the same name as long as the parameters are different

        private readonly decimal _amount;
        private readonly double _rate;
        private readonly int _term;
        private readonly decimal _monthlyPayment;

        public LoanUtilities(Loan loan)
        {
            _amount = loan.Amount;
            _rate = loan.Rate / 1200;
            _term = loan.Term;
            _monthlyPayment = MonthlyPayment();
        }


        public Loan CreateSchedule()
        {
            Loan loan = new Loan();
            loan.Payment = _monthlyPayment;
            var totalInterest = 0.00m;
            var balance = _amount;

            for (int i = 1; i <= _term; i++)
            {
                var loanPayment = new LoanPayment();
                loanPayment.MonthlyInterest = MonthlyInterest(balance);
                loanPayment.MonthlyPrincipal = _monthlyPayment - loanPayment.MonthlyInterest;
                loanPayment.Month = i;
                loanPayment.TotalInterest = totalInterest += loanPayment.MonthlyInterest;
                loanPayment.Balance = balance -= loanPayment.MonthlyPrincipal;

                loan.Payments.Add(loanPayment);

            }

            return loan;
        }


        private decimal MonthlyPayment()
        {
            var numerator = _amount * Convert.ToDecimal(_rate);
            var denominator = Convert.ToDecimal(1 - Math.Pow(1 + _rate, -_term));

            return numerator / denominator;
        }


        private decimal MonthlyInterest(decimal balance)
        {
            return balance * (decimal)_rate;
        }

    }

}
