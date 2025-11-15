using System.Collections.Generic;

namespace Calculator.Core.Abstractions
{
	public interface IResultsSaves
	{
		List<string> LoadResults();
		void SaveResults(string newResult);
	}
}