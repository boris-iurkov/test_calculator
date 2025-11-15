using Calculator.Core.Abstractions;
using UnityEngine;

namespace Calculator.App.Infrastructure
{
	public class PlayerPrefsInputSaves : IInputSaves
	{
		private const string InputKey = "InputKey";
		
		public string LoadInput()
		{
			if (!PlayerPrefs.HasKey(InputKey))
				return string.Empty;

			return PlayerPrefs.GetString(InputKey);
		}

		public void SaveInput(string input)
		{
			PlayerPrefs.SetString(InputKey, input);
			PlayerPrefs.Save();
		}
	}
}