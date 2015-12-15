using System;

namespace MvvmDemo.Services
{
    public class Calculator : ICalculator
    {
        public int Calculate(int opeartionId, int firstOperand, int secondOperand)
        {
            switch (opeartionId)
            {
                case 0:
                    return firstOperand + secondOperand;
                case 1:
                    return firstOperand - secondOperand;
                case 2:
                    return firstOperand * secondOperand;
                case 3:
                    return firstOperand | secondOperand;
                case 4:
                    return firstOperand & secondOperand;
                case 5:
                    return firstOperand ^ secondOperand;
                default:
                    throw new ArgumentException("Operation is not supported");
            }
        }
    }
}
