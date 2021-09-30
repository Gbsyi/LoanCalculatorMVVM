using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanCalculator.Models;

namespace LoanCalculator.ViewModels
{
    class LoanViewModel : INotifyPropertyChanged
    {
        private DiffLoanModel LoanModel = new();
        //Инициализация Amount
        private double _amount;
        public double Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                OnPropertyChanged("Amount");
            }
        }

        //Инициализация InterestRate
        private double _interestRate;
        public double InterestRate
        {
            get { return _interestRate; }
            set
            {
                _interestRate = value;
                OnPropertyChanged("InterestRate");
            }
        }

        //Инициализация Months
        private int _months;
        public int Months
        {
            get { return _months; }
            set
            {
                _months = value;
                OnPropertyChanged("Months");
            }
        }

        //Инициализация IsInterestPerYear
        private bool _isInterestPerYear;
        public bool IsInterestPerYear
        {
            get { return _isInterestPerYear; }
            set
            {
                _isInterestPerYear = value;
                OnPropertyChanged("IsInterestPerYear");
            }
        }

        //Получаем список из модели
        public List<double> GetPayments
        {
            get{ return LoanModel.Payments; }
        }

        //Реализация интерфейса
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
