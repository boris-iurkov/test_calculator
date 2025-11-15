using TMPro;
using UnityEngine;

namespace Calculator.UI.CalculatorView
{
		public class ExpressionResultView : MonoBehaviour
	{
		[SerializeField] private RectTransform rectTransform;
		[SerializeField] private TextMeshProUGUI label;

		public RectTransform RectTransform => rectTransform;
		
		public void Init(string text)
		{
			label.SetText(text);
		}

		public void Clear()
		{
			label.SetText(string.Empty);
		}
	}
}