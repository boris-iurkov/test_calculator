using System;
using Calculator.Presenter.Abstractions;
using UnityEngine;
using UnityEngine.UI;

namespace Calculator.UI.InfoPopupView
{
	public class InfoPopupView : MonoBehaviour, IInfoPopupView
	{
		[SerializeField] private Button buttonClose;
		
		public event Action OnClose;
		
		private void OnEnable()
		{
			buttonClose.onClick.AddListener(OnButtonCloseClick);
		}

		private void OnDisable()
		{
			buttonClose.onClick.RemoveListener(OnButtonCloseClick);
		}

		public void Show()
		{
			gameObject.SetActive(true);
		}

		public void Hide()
		{
			gameObject.SetActive(false);
		}
		
		private void OnButtonCloseClick()
		{
			OnClose?.Invoke();
		}
	}
}