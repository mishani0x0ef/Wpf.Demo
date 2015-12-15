using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MvvmDemo.Model;
using MvvmDemo.Services;

namespace MvvmDemo.ViewModel
{
    // View Model нашої MainView. Вона наслідується від класа ViewModelBase з ліби GalaSoft.MvvmLight, яку я підключив в менеджері пакетів.
    // Базовий клас ViewModelBase надає нам всі потрібні засоби для реалізації байндінгу даних і команд.
    public class MainViewModel : ViewModelBase
    {
        // Оголошення сервісу для діставання списків операцій та їх типів.
        public IOperationRepository OperationRepository { get; set; }
        // Оголошення сервісу, який рахуватиме для нас кінцевий результат виконання нашої програми.
        public ICalculator Calculator { get; set; }

        // ObservableCollection - спеціальний тип колекцій, який використовується зокрема в WPF. В ньому вбудовані механізми, які дозволяють реалізувати привязку даних.
        // Щоразу як така колекція змінюється (додають чи видаляються дані) вона сигналізує оточення про цю зміну, щоб механізм WPF зміг оновити відображення. 
        public ObservableCollection<OperationTypeModel> OperationTypes { get; set; }

        private OperationTypeModel _currentOperationType;
        public OperationTypeModel CurrentOperationType
        {
            get { return _currentOperationType; }
            set
            {
                _currentOperationType = value;
                // Коли змінюється поточний тип операції нам потрібно обновити список доступних операцій, які відповідають цьому типу.
                UpdateOperations();
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<OperationModel> Operations{ get; set; }

        private OperationModel _currentOperation;
        public OperationModel CurrentOperation
        {
            get { return _currentOperation; }
            set
            {
                _currentOperation = value;
                RaisePropertyChanged();
            }
        }

        private int _firstOperand;
        public int FirstOperand
        {
            get { return _firstOperand; }
            set
            {
                _firstOperand = value;
                RaisePropertyChanged();
            }
        }

        private int _secondOperand;
        public int SecondOperand
        {
            get { return _secondOperand; }
            set
            {
                _secondOperand = value;
                RaisePropertyChanged();
            }
        }

        private int _calculationResult;
        public int CalculationResult
        {
            get { return _calculationResult; }
            set
            {
                _calculationResult = value;
                RaisePropertyChanged();
            }
        }

        // ICommand - використовується для отримання сигналів від View про необхідність виконання якихось дій. 
        // В даному випдку натиснення на кнопку на MainView сигналізуватиме MainViewModel, що потрібно виконати метод Calculate.
        private ICommand _calculateCmd;
        public ICommand CalculateCmd
        {
            get { return _calculateCmd ?? (_calculateCmd = new RelayCommand(Calculate)); }
        }

        public MainViewModel()
        {
            OperationRepository = new OperationInMemoryRepository();
            Calculator = new Calculator();

            Initialize();
        }

        // Заповнення початкових даних.
        private void Initialize()
        {
            OperationTypes = OperationRepository.GetOperationTypes();
            Operations = new ObservableCollection<OperationModel>();
        }

        private void UpdateOperations()
        {
            Operations.Clear();

            var operations = OperationRepository.GetOperations(CurrentOperationType.OperationType);

            foreach (var operation in operations)
            {
                Operations.Add(operation);
            }
        }

        private void Calculate()
        {
            if (CurrentOperation == null)
            {
                MessageBox.Show("Операція не обрана");
                return;
            }
            CalculationResult = Calculator.Calculate(CurrentOperation.OperationId, FirstOperand, SecondOperand);
        }
    }
}