using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanCalculator
{
    public struct Payments
    {
        public Payments(int index, DateTime paymentDate, double payment, double percents, double residue)
        {
            Index = index;
            PaymentDate = paymentDate;
            Payment = payment;
            Percents = percents;
            Residue = residue;
        }
        public int Index;
        public DateTime PaymentDate;
        public double Payment;
        public double Percents;
        public double Residue;

    }

}
