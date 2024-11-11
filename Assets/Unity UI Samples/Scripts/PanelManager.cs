using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class PanelManager : MonoBehaviour {
	// 用于管理面板的打开和关闭
	public Animator initiallyOpen;

	private int m_OpenParameterId;
	private Animator m_Open;
	private GameObject m_PreviouslySelected;

	const string k_OpenTransitionName = "Open";
	const string k_ClosedStateName = "Closed";

	public void OnEnable()//在启用时调用
	{
		m_OpenParameterId = Animator.StringToHash (k_OpenTransitionName);

		if (initiallyOpen == null)
			return;

		OpenPanel(initiallyOpen);
	}

	public void OpenPanel (Animator anim)//打开面板
	{
		if (m_Open == anim)
			return;

		anim.gameObject.SetActive(true);//设置游戏对象为激活状态
		var newPreviouslySelected = EventSystem.current.currentSelectedGameObject;//当前选择的游戏对象

		anim.transform.SetAsLastSibling();//设置为最后一个兄弟

		CloseCurrent();//关闭当前

		m_PreviouslySelected = newPreviouslySelected;//新的先前选择的游戏对象

		m_Open = anim;//新的打开的动画
		m_Open.SetBool(m_OpenParameterId, true);//设置布尔值

		GameObject go = FindFirstEnabledSelectable(anim.gameObject);//查找第一个启用的可选择对象

		SetSelected(go);
	}

	static GameObject FindFirstEnabledSelectable (GameObject gameObject)//查找第一个启用的可选择对象
	{
		GameObject go = null;//游戏对象
		var selectables = gameObject.GetComponentsInChildren<Selectable> (true);
		foreach (var selectable in selectables) {
			if (selectable.IsActive () && selectable.IsInteractable ()) {
				go = selectable.gameObject;
				break;
			}
		}
		return go;
	}

	public void CloseCurrent()//关闭当前
	{
		if (m_Open == null)
			return;

		m_Open.SetBool(m_OpenParameterId, false);
		SetSelected(m_PreviouslySelected);
		StartCoroutine(DisablePanelDeleyed(m_Open));
		m_Open = null;
	}

	IEnumerator DisablePanelDeleyed(Animator anim)//延迟禁用面板
	{
		bool closedStateReached = false;
		bool wantToClose = true;
		while (!closedStateReached && wantToClose)
		{
			if (!anim.IsInTransition(0))
				closedStateReached = anim.GetCurrentAnimatorStateInfo(0).IsName(k_ClosedStateName);

			wantToClose = !anim.GetBool(m_OpenParameterId);

			yield return new WaitForEndOfFrame();
		}

		if (wantToClose)
			anim.gameObject.SetActive(false);
	}

	private void SetSelected(GameObject go)//设置选择
	{
		EventSystem.current.SetSelectedGameObject(go);
	}

	public void Store(){
		//转移到商店界面scene
		UnityEngine.SceneManagement.SceneManager.LoadScene("Store");
	}
}
