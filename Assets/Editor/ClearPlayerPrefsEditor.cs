using UnityEditor;
using UnityEngine;

namespace Editor
{
	public static class ClearPlayerPrefsEditor
	{
		[MenuItem("Tools/Clear PlayerPrefs")]
		public static void ClearPlayerPrefs()
		{
			PlayerPrefs.DeleteAll();
			PlayerPrefs.Save();
		}
	}
}