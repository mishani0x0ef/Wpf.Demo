using System.Windows;
using MvvmDemo.View;
using MvvmDemo.ViewModel;

namespace MvvmDemo
{
    // Головний клас всієї програми. Місце, де ваша програма стартує.
    public partial class App : Application
    {
        // Обробник події запуску програми.
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Створюємо View, присвоюємо їй контекст даних (місце звідки бартимуться дані для байндінга) і показуємо.
            var mainView = new MainView {DataContext = new MainViewModel()};
            mainView.Show();
        }
    }
}
