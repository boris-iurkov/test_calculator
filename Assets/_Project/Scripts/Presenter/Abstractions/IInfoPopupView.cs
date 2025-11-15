using System;

namespace Calculator.Presenter.Abstractions
{
	public interface IInfoPopupView
	{
		event Action OnClose;
		
		void Show();
		void Hide();
	}
}