using Calculator.Core.Data;

namespace Calculator.Core.Abstractions
{
	public interface ICalculatorService
	{
		bool IsValid(string raw);
		int Calculate(Expression expression);
	}
}