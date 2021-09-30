using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LoanCalculator.Models;

namespace LoanCalculator.ViewModels
{
    class LoanViewModel : INotifyPropertyChanged
    {
        private DiffLoanModel LoanModel = new();
        //Инициализация Amount
        private double _amount = 100000;
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
        private double _interestRate = 10;
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
        private int _months = 6;
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
        
        //Нажатие кнопки
        public ICommand CalculateClick { get; set; }

        public LoanViewModel()
        {
            CalculateClick = new DelegateCommand(o => Calculate("CalculateClick"));
        }

        private void Calculate(object sender)
        {
            LoanModel.CalculateLoan(_amount, _interestRate, _months, _isInterestPerYear);
            OnPropertyChanged("GetPayments");
        }
        //Реализация интерфейса
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
