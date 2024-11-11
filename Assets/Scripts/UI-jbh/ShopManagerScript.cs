using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;


public class ShopManagerScript : MonoBehaviour
{   
    //int[10,5]是一个二维数组
    //物品数量是5,物品性质有10种
    public int[,] shopItems = new int[5, 6];//物品性质4，物品数量5，不使用index0,以防报错
    public int coins;
    public Text coinsTxt;

    void Start()
    {
        coinsTxt.text = coins.ToString();

        //物品ID
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;
        shopItems[1, 5] = 5;

        //物品价格
        shopItems[2, 1] = 10;
        shopItems[2, 2] = 20;
        shopItems[2, 3] = 30;
        shopItems[2, 4] = 40;
        shopItems[2, 5] = 50;

        //物品数量,即等级
        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;
        shopItems[3, 4] = 0;
        shopItems[3, 5] = 0;

        //物品最大数量，即最高等级，或者最大宠物数量
        shopItems[4, 1] = 3;
        shopItems[4, 2] = 3;
        shopItems[4, 3] = 3;
        shopItems[4, 4] = 3;
        shopItems[4, 5] = 3;
    }

    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        //查看是否有足够的金币
        if(coins >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID])
        {
            //查看是否有足够的物品
            if(shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID] < shopItems[4, ButtonRef.GetComponent<ButtonInfo>().ItemID])
            {
                //需要修改到存档
                coins -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];//减去对应价格的金币
                //重新显示金币数量
                coinsTxt.text = coins.ToString();
                shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++;
                //重新显示物品数量
                ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = "等级：" + shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString() + "/" + shopItems[4, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
            }
        }
    }
}
