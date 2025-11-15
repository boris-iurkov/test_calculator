using Calculator.Core.Abstractions;
using Calculator.Core.Common;
using Calculator.Core.Data;

namespace Calculator.Core.Implementations
{
	public class CalculatorService : ICalculatorService
	{
		public bool IsValid(string raw)
		{
			return ExpressionValidator.IsValid(raw);
		}

		public int Calculate(Expression expression)
		{
			string raw = expression.Raw;
			string[] parts = raw.Split(CalculatorConstants.AdditionOperator);

			var sum = 0;
			foreach (string part in parts)
			{
				sum += int.Parse(part);
			}

			return sum;
		}
	}
}