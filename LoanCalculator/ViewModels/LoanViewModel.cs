using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        //Получаем таблицу из модели
        private ObservableCollection<Payments> _loanPayments;
        public ObservableCollection<Payments> LoanPayments
        {
            get { return _loanPayments; }
            set
            {
                _loanPayments = value;
                OnPropertyChanged("LoanPayments");
            }
        }
        
        //Инициализируем TotalPayment
        private double _totalPayment;
        public double TotalPayment
        {
            get { return _totalPayment; }
            set
            {
                _totalPayment = value;
                OnPropertyChanged("TotalPayment");
            }
        }
        //Инициализируем Overpayment
        private double _overpayment;
        public double Overpayment
        {
            get { return _overpayment; }
            set
            {
                _overpayment = value;
                OnPropertyChanged("Overpayment");
            }
        }
        private double _mainPayment;
        public double MainPayment
        {
            get { return _mainPayment; }
            set 
            { 
                _mainPayment = value;
                OnPropertyChanged("MainPayment");
            }
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
            LoanPayments = LoanModel.LoanPayments;
            Overpayment = LoanModel.Overpayment;
            TotalPayment = LoanModel.TotalPayment;
            MainPayment = LoanModel.MainPayment;

        }
        //Реализация интерфейса
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
