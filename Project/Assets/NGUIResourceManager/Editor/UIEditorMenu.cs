using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine;
public class UIEditorMenu {
	[MenuItem("UIEditor/Unload All Resources")]
	//how to unload all the resources in editor???
	public static void UnloadAllResources()
	{
		Caching.CleanCache();
		Resources.UnloadUnusedAssets();
	}
}
