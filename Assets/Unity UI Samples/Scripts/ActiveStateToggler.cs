using UnityEngine;
using System.Collections;

public class ActiveStateToggler : MonoBehaviour {
	// 用于切换游戏对象的激活状态
	public void ToggleActive () {
		gameObject.SetActive (!gameObject.activeSelf);
	}
}
