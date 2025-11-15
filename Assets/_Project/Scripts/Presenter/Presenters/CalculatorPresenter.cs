using System;
using System.Collections.Generic;
using System.Text;
using Calculator.Core.Abstractions;
using Calculator.Core.Common;
using Calculator.Core.Data;
using Calculator.Presenter.Abstractions;

namespace Calculator.Presenter.Presenters
{
	public class CalculatorPresenter : IDisposable
	{
		private readonly ICalculatorService _service;
		private readonly IResultsSaves _resultsSaves;
		private readonly IInputSaves _inputSaves;
		private readonly ICalculatorView _calculatorView;
		private readonly IInfoPopupView _infoPopupView;

		public CalculatorPresenter(
			ICalculatorService service, 
			IResultsSaves resultsSaves,
			IInputSaves inputSaves,
			ICalculatorView calculatorView, 
			IInfoPopupView infoPopupView)
		{
			_service = service;
			_resultsSaves = resultsSaves;
			_inputSaves = inputSaves;
			_calculatorView = calculatorView;
			_infoPopupView = infoPopupView;
		}

		public void Init()
		{
			_calculatorView.OnResult += OnResult;
			_calculatorView.OnInputChanged += OnInputChanged;
			_infoPopupView.OnClose += OnInfoPopupClose;
			
			_calculatorView.Show();
			_infoPopupView.Hide();
			
			LoadResults();
			LoadInput();
		}

		public void Dispose()
		{
			_calculatorView.OnResult -= OnResult;
			_calculatorView.OnInputChanged -= OnInputChanged;
			_infoPopupView.OnClose -= OnInfoPopupClose;
			
			_calculatorView.Clear();
		}

		private void LoadResults()
		{
			List<string> results = _resultsSaves.LoadResults();
			int resultsCount = results.Count;
			for(var i = 0; i < resultsCount; i++)
			{
				bool lastItem = i + 1 == resultsCount;
				AddResult(results[i], lastItem);
			}

			if (resultsCount == 0)
				_calculatorView.UpdateResultsContainerHeight();
		}

		private void LoadInput()
		{
			string input = _inputSaves.LoadInput();
			if (!string.IsNullOrWhiteSpace(input))
				_calculatorView.SetInput(input);
		}
		
		private void OnResult()
		{
			string raw = _calculatorView.InputText;
			
			var textResult = new StringBuilder(raw);
			textResult.Append(CalculatorConstants.EqualsSign);
			
			if (_service.IsValid(raw))
			{
				var expression = new Expression(raw);
				int result = _service.Calculate(expression);
				
				textResult.Append(result);
				
				_calculatorView.ClearInputField();
			}
			else
			{
				textResult.Append(CalculatorConstants.ErrorText);

				_calculatorView.Hide();
				_infoPopupView.Show();
			}

			var text = textResult.ToString();
			AddResult(text, true);
			SaveResult(text);
		}

		private void AddResult(string text, bool updateContainerHeight)
		{
			_calculatorView.AddResult(text, updateContainerHeight);
		}

		private void SaveResult(string text)
		{
			_resultsSaves.SaveResults(text);
		}
		
		private void OnInputChanged()
		{
			string text = _calculatorView.InputText;
			SaveInput(text);
		}

		private void SaveInput(string text)
		{
			_inputSaves.SaveInput(text);
		}

		private void OnInfoPopupClose()
		{
			_infoPopupView.Hide();
			_calculatorView.Show();
		}
	}
}