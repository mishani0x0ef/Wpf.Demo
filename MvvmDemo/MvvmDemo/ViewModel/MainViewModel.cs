using GalaSoft.MvvmLight;

namespace MvvmDemo.ViewModel
{
    // View Model нашої MainView. Вона наслідується від класа ViewModelBase з ліби GalaSoft.MvvmLight, яку я підключив в менеджері пакетів.
    // Базовий клас ViewModelBase надає нам всі потрібні засоби для реалізації байндінгу даних і команд.
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
        }
    }
}