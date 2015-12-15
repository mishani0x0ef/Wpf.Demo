using MvvmDemo.Model;

namespace MvvmDemo.Services
{
    public interface ICalculator
    {
        int Calculate(int operationId, int firstOperand, int secondOperand);
    }
}
