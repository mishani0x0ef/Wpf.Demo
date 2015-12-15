using GalaSoft.MvvmLight;

namespace MvvmDemo.Model
{
    // Модель, яка наслідується від ObservableObject, який надає нам основні функції для привязки даних
    public class OperationTypeModel : ObservableObject
    {
        // Це пара приватний філд - публічна пропертя. Які використовуються для зберігання даних.
        private OperationType _operationType;
        public OperationType OperationType
        {
            get { return _operationType; }
            set
            {
                // Коли ми десь в коді напишемо OperationTypeModel.OperationType = 1, - ми присвоємо значення в приватний філд і викличемо RaisePropertyChanged
                // RaisePropertyChanged - дозволяє зрозуміти механізму WPF, що обякт змінився і потрібно оновити відображення.
                _operationType = value;
                RaisePropertyChanged();
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                RaisePropertyChanged();
            }
        }
    }
}
