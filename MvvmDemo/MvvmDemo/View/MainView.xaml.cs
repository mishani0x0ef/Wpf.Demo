using System.Windows;

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
    }
}
