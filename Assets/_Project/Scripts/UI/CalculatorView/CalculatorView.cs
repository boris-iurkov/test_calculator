using System;
using System.Collections.Generic;
using Calculator.Presenter.Abstractions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Calculator.UI.CalculatorView
{
	public class CalculatorView : MonoBehaviour, ICalculatorView
	{
		[SerializeField] private TMP_InputField inputField;
		[SerializeField] private ExpressionResultView resultViewPrefab;
		[SerializeField] private RectTransform resultsContainer;
		[SerializeField] private ScrollResizer scrollResizer;
		[SerializeField] private Button buttonResult;
		[SerializeField] private CanvasGroup canvasGroup;

		public event Action OnResult;
		public event Action OnInputChanged;
		public string InputText => inputField.text;
		
		private ExpressionResultViewPool _pool;
		private List<ExpressionResultView> _resultsViews;

		private void Awake()
		{
			_pool = new ExpressionResultViewPool(resultViewPrefab, resultsContainer);
			_resultsViews = new List<ExpressionResultView>();
		}

		private void OnEnable()
		{
			buttonResult.onClick.AddListener(OnButtonResultClick);
			inputField.onValueChanged.AddListener(OnInputTextChanged);
		}

		private void OnDisable()
		{
			buttonResult.onClick.RemoveListener(OnButtonResultClick);
			inputField.onValueChanged.RemoveListener(OnInputTextChanged);
		}
		
		public void Show()
		{
			canvasGroup.alpha = 1;
		}

		public void Hide()
		{
			canvasGroup.alpha = 0;
		}

		public void AddResult(string text, bool updateContainerHeight)
		{
			ExpressionResultView result = _pool.GetView();
			result.Init(text);
			result.RectTransform.SetSiblingIndex(0);
			_resultsViews.Add(result);

			if (updateContainerHeight)
				UpdateResultsContainerHeight();
		}

		public void UpdateResultsContainerHeight()
		{
			scrollResizer.UpdateContainerHeight();
		}

		public void SetInput(string text)
		{
			inputField.text = text;
		}

		public void ClearInputField()
		{
			inputField.text = "";
		}

		public void Clear()
		{
			foreach (ExpressionResultView resultView in _resultsViews)
			{
				resultView.Clear();
				_pool.ReturnView(resultView);
			}
		}
		
		private void OnButtonResultClick()
		{
			OnResult?.Invoke();
		}
		
		private void OnInputTextChanged(string newText)
		{
			OnInputChanged?.Invoke();
		}
	}
}