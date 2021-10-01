using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanCalculator.Models
{
    class DiffLoanModel
    {
        //private
        private DateTime date = DateTime.Now;

        //public
        public double Overpayment;
        public List<double> Paymentss = new List<double>();
        public ObservableCollection<Payments> LoanPayments = new ObservableCollection<Payments>();
        public double TotalPayment;
        public double MainPayment { get; private set; }

        public void CalculateLoan(double amount, double interestRate, int months, bool isInterestPerYear)
        {
            TotalPayment = 0;
            LoanPayments = new ObservableCollection<Payments>();
            MainPayment = Math.Round(amount / months, 5, MidpointRounding.ToEven);
            interestRate /= 100;

            if (isInterestPerYear) { interestRate /= 12; }

            for (int index = 0; index < months; index++)
            {
                double currentPayment = Math.Round(MainPayment + (amount - (MainPayment * index)) * interestRate, 2, MidpointRounding.ToEven);
                TotalPayment += currentPayment;
                LoanPayments.Add(new Payments(
                    index + 1, //Index
                    date.AddMonths(index),
                    currentPayment, //Payment
                    Math.Round(currentPayment - MainPayment, 2, MidpointRounding.ToEven), //Percents
                    Math.Round(amount - MainPayment * (index + 1), 2, MidpointRounding.AwayFromZero)
                    ));
            }

            Overpayment = Math.Round(TotalPayment - amount, 2, MidpointRounding.ToEven);
        }
    }
}
