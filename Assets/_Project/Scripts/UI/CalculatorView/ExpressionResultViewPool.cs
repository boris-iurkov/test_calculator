using System.Collections.Generic;
using UnityEngine;

namespace Calculator.UI.CalculatorView
{
	public class ExpressionResultViewPool
	{
		private readonly Stack<ExpressionResultView> _pool = new();
		private readonly RectTransform _parent;
		private readonly ExpressionResultView _prefab;
		
		public ExpressionResultViewPool(ExpressionResultView prefab, RectTransform parent)
		{
			_prefab = prefab;
			_parent = parent;
		}
		
		public ExpressionResultView GetView()
		{
			if (_pool.Count > 0)
			{
				ExpressionResultView view = _pool.Pop();
				view.gameObject.SetActive(true);
				return view;
			}

			return Object.Instantiate(_prefab, _parent);
		}

		public void ReturnView(ExpressionResultView view)
		{
			view.gameObject.SetActive(false);
			_pool.Push(view);
		}
	}
}