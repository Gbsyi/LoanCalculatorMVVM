using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanCalculator.Models
{
    class DiffLoanModel
    {
        private double _overpayment;
        public List<double> Payments = new List<double>();
        private double _totalPayment = 0;
        public double MainPayment { get; private set; }
        public double GetOverpayment()
        {
            return _overpayment;
        }
        public double GetTotalPayment()
        {
            return _totalPayment;
        }
        public void CalculateLoan(double loan, double interestRate, int months, bool isInterestPerYear)
        {
            MainPayment = loan / months;
            interestRate /= 100;

            if (isInterestPerYear) { interestRate /= 12; }

            for (int index = 0; index < months; index++)
            {
                Payments.Add(Math.Round(MainPayment + (loan - (MainPayment * index)) * interestRate, 2, MidpointRounding.ToEven));
                _totalPayment += Payments[index];
            }

            _overpayment = Math.Round(_totalPayment - loan, 2, MidpointRounding.ToEven);
        }
    }
}
