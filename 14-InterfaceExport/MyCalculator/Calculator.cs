using System;
using System.Collections.Generic;

namespace Wrox.ProCSharp.Composition
{
    ////a wild calculator
    public class Calculator : ICalculator
    {
        public IList<IOperation> GetOperations() => new List<IOperation>()
            {
                new Operation { Name="!", NumberOperands=2},
                new Operation { Name="@", NumberOperands=2},
                new Operation { Name="#", NumberOperands=2},
                new Operation { Name="$", NumberOperands=2}
            };

        public double Operate(IOperation operation, double[] operands)
        {
            double result = 0;
            switch (operation.Name)
            {
                case "!":
                    result = (operands[0] + operands[1])*0.618;
                    break;
                case "@":
                    result = (operands[0] - operands[1])*2.71828;
                    break;
                case "#":
                    result = Math.Pow(operands[0] / operands[1],2);
                    break;
                case "$":
                    result = operands[0] * operands[1]*Math.PI;
                    break;
                default:
                    throw new InvalidOperationException($"invalid operation {operation.Name}");
            }
            return result;
        }
    }
}
