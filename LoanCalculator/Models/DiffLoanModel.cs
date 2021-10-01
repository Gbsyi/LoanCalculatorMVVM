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
        private double _overpayment;
        public List<double> Paymentss = new List<double>();
        public ObservableCollection<Payments> LoanPayments = new ObservableCollection<Payments>();
        private double _totalPayment = 0;
        private DateTime date = DateTime.Now;
        public double MainPayment { get; private set; }
        public double GetOverpayment()
        {
            return _overpayment;
        }
        public double GetTotalPayment()
        {
            return _totalPayment;
        }

        public void CalculateLoan(double amount, double interestRate, int months, bool isInterestPerYear)
        {
            LoanPayments = new ObservableCollection<Payments>();
            MainPayment = Math.Round(amount / months, 2, MidpointRounding.ToEven);
            interestRate /= 100;

            if (isInterestPerYear) { interestRate /= 12; }

            for (int index = 0; index < months; index++)
            {
                double currentPayment = Math.Round(MainPayment + (amount - (MainPayment * index)) * interestRate, 2, MidpointRounding.ToEven);
                _totalPayment += currentPayment;
                LoanPayments.Add(new Payments(
                    index + 1, //Index
                    date.AddMonths(index),
                    currentPayment, //Payment
                    Math.Round(currentPayment - MainPayment, 2, MidpointRounding.ToEven), //Percents
                    amount - _totalPayment
                    ));
            }

            _overpayment = Math.Round(_totalPayment - amount, 2, MidpointRounding.ToEven);
        }
    }
}
