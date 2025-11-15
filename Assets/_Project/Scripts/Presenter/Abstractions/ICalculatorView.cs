using System;

namespace Calculator.Presenter.Abstractions
{
	public interface ICalculatorView
	{
		event Action OnResult;
		event Action OnInputChanged;
		string InputText { get; }
		
		void Show();
		void Hide();
		void AddResult(string text, bool updateContainerHeight);
		void UpdateResultsContainerHeight();
		void SetInput(string text);
		void ClearInputField();
		void Clear();
	}
}