using System.Windows;
using System.Windows.Input;

namespace MvvmDemo.View
{
    // Закулісний код нашої головної вюхи. Тут можна робити речі, які не повязані з бізнес логікою, а впливають на відображення
    // Наприклад: складні ефекти, які не можна написати на XAML, тощо. Одним словом чіпати цей клас нам по суті і не треба.
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        }

        // Обмежуємо допустимий ввід в наші текстові поля тільки цифрами.
        // Обробка подій натискання кнопки не відповідає практикам MVVM. 
        // Є кращі шляхи реалізації такого обмеження, але вони б ускладнили цей приклад. Тому для розуміння зроблено так.
        private void UIElement_OnKeyDown(object sender, KeyEventArgs e)
        {
            var isNumeric = e.Key >= Key.D0 && e.Key <= Key.D9;
            isNumeric = isNumeric || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9);
            var isControl = e.Key == Key.Delete || e.Key == Key.Back;
            if (!isNumeric && !isControl)
            {
                e.Handled = true;
            }
        }
    }
}
