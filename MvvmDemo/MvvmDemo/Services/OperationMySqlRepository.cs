using System.Collections.ObjectModel;
using System.Data;
using MvvmDemo.Model;
using MySql.Data.MySqlClient;

namespace MvvmDemo.Services
{
    // Цей клас показує як можна працювати з MySql в .NET
    // Перш за все потрібно додати в проект бібліотеку MySql.Data.MySqlClient. Її можна скачати з інтернету чи інсталювати менеджером пакетів.
    // Цей клас не слідує кращим практикам розробки слоя доступу до даних, щоб не ускладнювати його розуміння.
    // Він просто показує загальні речі, без яких не обійтись при роботі з БД.
    // База даних з якою працює клас є чисто уявною.
    public class OperationMySqlRepository : IOperationRepository
    {
        private const string ConnectionString =
            "Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;";

        public ObservableCollection<OperationTypeModel> GetOperationTypes()
        {
            // Визначаємо скріпт, який буде виконуватися на базі даних.
            const string commandText = "select * from dbo.OperationType";

            var operationTypes = new ObservableCollection<OperationTypeModel>();

            // Відкриваємо конекшн до бази даних і створюємо команду яку будемо виконувати.
            using (var connection = new MySqlConnection(ConnectionString))
            using (var command = new MySqlCommand(commandText, connection))
            {
                // Відкриваємо конекшн. На цьому етапі .NET звяжеться з движком БД і попросить виділити доступний конекшн.
                connection.Open();
                
                // Виконуємо команду і отримуємо результат у вигляді читача даних
                var reader = command.ExecuteReader();

                // Зчитуємо отримані дані. Кожна ітерація циклу - зчитування одного рядка.
                while (reader.Read())
                {
                    // Створюємо читаємо значення поточного рядка і будуємо свій обєкт.
                    var operationType = GetOperationTypeFromReader(reader);

                    operationTypes.Add(operationType);
                }
            }
            // Після завершення блоку using конекшн до бази даних автоматично закриється.

            return operationTypes;
        }

        public ObservableCollection<OperationModel> GetOperations(OperationType operationType)
        {
            // Замітьте, що в скрипту вказано OperationType = @operationType.
            // Це зроблено для того, щоб запобігти SQL інєкціям.
            // Параметр @operationType буде обявлений далі.
            const string commandText = "select * from dbo.Operation where OperationType = @operationType";

            var operations = new ObservableCollection<OperationModel>();

            using (var connection = new MySqlConnection(ConnectionString))
            using (var command = new MySqlCommand(commandText, connection))
            {
                connection.Open();

                // Визначаємо значення параметра @operationType
                command.Parameters.AddWithValue("@operationType", operationType);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var operation = GetOperationFromReader(reader);
                    operations.Add(operation);
                }
            }

            return operations;
        }

        // Метод для побудови обєкта з зчитивуча даних
        private OperationTypeModel GetOperationTypeFromReader(IDataReader reader)
        {
            return new OperationTypeModel
            {
                // reader["OperationType"] - назва всередині лапок відповідає назві стовпчика, з якого ми читаємо дані.
                OperationType = (OperationType) int.Parse(reader["OperationType"].ToString()),
                Description = reader["Description"].ToString()
            };
        }

        private OperationModel GetOperationFromReader(IDataReader reader)
        {
            return new OperationModel
            {
                OperationId = int.Parse(reader["OperationID"].ToString()),
                Description = reader["Description"].ToString(),
                Sign = reader["OperationSign"].ToString()
            };
        }
    }
}
