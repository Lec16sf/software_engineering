using UnityEngine;
using System.Collections;

public class ApplicationManager : MonoBehaviour {
	
	// 用于退出应用程序
	public void Quit () 
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}
}
