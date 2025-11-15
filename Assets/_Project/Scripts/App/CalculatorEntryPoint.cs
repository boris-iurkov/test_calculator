using Calculator.App.Infrastructure;
using Calculator.Core.Abstractions;
using Calculator.Core.Implementations;
using Calculator.Presenter.Abstractions;
using Calculator.Presenter.Presenters;
using Calculator.UI.CalculatorView;
using Calculator.UI.InfoPopupView;
using UnityEngine;

namespace Calculator.App
{
	public class CalculatorEntryPoint : MonoBehaviour
	{
		[SerializeField] private CalculatorView calculatorView;
		[SerializeField] private InfoPopupView infoPopupView;

		private CalculatorPresenter _presenter;
		
		private void Awake()
		{
			ICalculatorService service = new CalculatorService();
			IResultsSaves resultsSaves = new PlayerPrefsResultsSaves();
			IInputSaves inputSaves = new PlayerPrefsInputSaves();
			ICalculatorView calcView = calculatorView;
			IInfoPopupView infoView = infoPopupView;

			_presenter = new CalculatorPresenter(service, resultsSaves, inputSaves, calcView, infoView);
			_presenter.Init();
		}

		private void OnDestroy()
		{
			_presenter?.Dispose();
		}
	}
}