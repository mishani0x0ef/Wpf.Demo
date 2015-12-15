using GalaSoft.MvvmLight;

namespace MvvmDemo.Model
{
    public class OperationModel : ObservableObject
    {
        // Це пара приватний філд - публічна пропертя. Які використовуються для зберігання даних.
        private int _operationId;
        public int OperationId
        {
            get { return _operationId; }
            set
            {
                // Коли ми десь в коді напишемо OperationModel.OperationId = 1, - ми присвоємо значення в приватний філд і викличемо RaisePropertyChanged
                // RaisePropertyChanged - дозволяє зрозуміти механізму WPF, що обякт змінився і потрібно оновити відображення.
                _operationId = value;
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

        private string _sign;
        public string Sign
        {
            get { return _sign; }
            set
            {
                _sign = value;
                RaisePropertyChanged();
            }
        }
    }
}
