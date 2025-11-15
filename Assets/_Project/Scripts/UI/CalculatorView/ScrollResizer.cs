using UnityEngine;
using UnityEngine.UI;

namespace Calculator.UI.CalculatorView
{
	public class ScrollResizer : MonoBehaviour
	{
		[SerializeField] private ScrollRect scrollRect;
		[SerializeField] private RectTransform scrollContainer;
		[SerializeField] private RectTransform content;

		[Space]
		public float minHeight = 0;
		public float maxHeight = 560f;

		public void UpdateContainerHeight()
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(content);
			
			float contentHeight = content.sizeDelta.y;
			float newHeight = Mathf.Clamp(contentHeight, minHeight, maxHeight);

			Vector2 size = scrollContainer.sizeDelta;
			size.y = newHeight;
			scrollContainer.sizeDelta = size;

			scrollRect.verticalNormalizedPosition = 1f;
		}
	}
}