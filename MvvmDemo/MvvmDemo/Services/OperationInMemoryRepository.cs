using System;
using System.Collections.ObjectModel;
using MvvmDemo.Model;

namespace MvvmDemo.Services
{
    public class OperationInMemoryRepository : IOperationRepository
    {
        private ObservableCollection<OperationTypeModel> _operationTypes;
        private ObservableCollection<OperationModel> _logicalOperations;
        private ObservableCollection<OperationModel> _mathOperations;

        public OperationInMemoryRepository()
        {
            Initialize();
        }

        public ObservableCollection<OperationTypeModel> GetOperationTypes()
        {
            return _operationTypes;
        }

        public ObservableCollection<OperationModel> GetOperations(OperationType operationType)
        {
            switch (operationType)
            {
                case OperationType.Logical:
                    return _logicalOperations;
                case OperationType.Math:
                    return _mathOperations;
                default:
                    throw new ArgumentException("Operation type is not supported.");
            }
        }

        // Просто заганємо в наші колекції тестових даних.
        private void Initialize()
        {
            _operationTypes = new ObservableCollection<OperationTypeModel>
            {
                new OperationTypeModel {OperationType = OperationType.Logical, Description = "Логічні Операції"},
                new OperationTypeModel {OperationType = OperationType.Math, Description = "Математичні Операції"}
            };

            _mathOperations = new ObservableCollection<OperationModel>
            {
                new OperationModel {OperationId = 0, Description = "Додавання", Sign = "+"},
                new OperationModel {OperationId = 1, Description = "Віднімання", Sign = "-"},
                new OperationModel {OperationId = 2, Description = "Множення", Sign = "*"},
            };

            _logicalOperations = new ObservableCollection<OperationModel>
            {
                new OperationModel {OperationId = 3, Description = "Логічне АБО", Sign = "|"},
                new OperationModel {OperationId = 4, Description = "Логічне І", Sign = "&"},
                new OperationModel {OperationId = 5, Description = "Виключне АБО", Sign = "^"},
            };
        }
    }
}
