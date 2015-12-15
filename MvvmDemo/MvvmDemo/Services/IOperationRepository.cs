using System.Collections.ObjectModel;
using MvvmDemo.Model;

namespace MvvmDemo.Services
{
    public interface IOperationRepository
    {
        ObservableCollection<OperationTypeModel> GetOperationTypes();
        ObservableCollection<OperationModel> GetOperations(OperationType operationType);
    }
}
