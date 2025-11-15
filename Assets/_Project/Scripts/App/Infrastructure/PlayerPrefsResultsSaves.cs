using System;
using System.Collections.Generic;
using Calculator.Core.Abstractions;
using UnityEngine;

namespace Calculator.App.Infrastructure
{
	public class PlayerPrefsResultsSaves : IResultsSaves
	{
		private const string ResultsKey = "ResultsKey";
		
		public List<string> LoadResults()
		{
			if (!PlayerPrefs.HasKey(ResultsKey))
				return new List<string>();

			string json = PlayerPrefs.GetString(ResultsKey);
			var wrapper = JsonUtility.FromJson<Wrapper>(json);
			return wrapper?.items ?? new List<string>();
		}

		public void SaveResults(string newResult)
		{
			List<string> results = LoadResults();
			results.Add(newResult);
			
			var wrapper = new Wrapper { items = results };
			string json = JsonUtility.ToJson(wrapper);
			
			PlayerPrefs.SetString(ResultsKey, json);
			PlayerPrefs.Save();
		}
		
		[Serializable]
		private class Wrapper
		{
			public List<string> items;
		}
	}
}