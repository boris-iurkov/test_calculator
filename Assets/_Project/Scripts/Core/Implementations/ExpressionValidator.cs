using System.Linq;
using Calculator.Core.Common;

namespace Calculator.Core.Implementations
{
	public static class ExpressionValidator
	{
		public static bool IsValid(string raw)
		{
			if (string.IsNullOrWhiteSpace(raw))
				return false;

			string[] parts = raw.Split(CalculatorConstants.AdditionOperator);

			if (parts.Length < 2)
				return false;

			foreach (string part in parts)
			{
				if (string.IsNullOrWhiteSpace(part))
					return false;
				
				if (string.IsNullOrEmpty(part) || !part.All(char.IsDigit))
					return false;
			}

			return true;
		}
	}
}