using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscMenu : MonoBehaviour
{
    public GameObject escMenu;//菜单列表
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            escMenu.SetActive(!escMenu.activeSelf);
            if(escMenu.activeSelf){
                Time.timeScale = 0;
            }else{
                Time.timeScale = 1;
            }
        }
    }
}
