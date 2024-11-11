using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;


public class ShopManagerScript : MonoBehaviour
{   
    //int[10,5]是一个二维数组
    //物品数量是5,物品性质有10种
    public int[,] shopItems = new int[5, 20];//物品性质4，物品数量19，不使用index0,以防报错
    public string[] buffName = new string[20];
    public int coins;
    public Text coinsTxt;
    public int[] buffLevel = new int[20];
    public GameSave data;

    void Start()
    {
        Load();
        coinsTxt.text = coins.ToString();

        //物品ID
        for(int i = 1; i < 20; i++)
        {
            shopItems[1, i] = i;
        }

        //物品价格
        for(int i = 1; i < 20; i++)
        {
            shopItems[2, i] = 10;
        }

        //物品数量,即等级
        for(int i = 1; i < 20; i++)
        {
            shopItems[3, i] = buffLevel[i-1];
        }

        //物品最大数量，即最高等级，或者最大宠物数量
        for(int i = 1; i < 20; i++)
        {
            shopItems[4, i] = 3;
        }

        //物品名称
        buffName[1] = "子弹速度";   // buff0
        buffName[2] = "子弹射速";   // buff1
        buffName[3] = "子弹耐久";   // buff2
        buffName[4] = "子弹数量";   // buff3
        buffName[5] = "初始血量";   // buff4
        buffName[6] = "血量倍增";   // buff5
        buffName[7] = "横向速度";   // buff6
        buffName[8] = "子弹伤害";   // buff7
        buffName[11] = "撞击免伤";  // buff10

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
                Load();
                //需要修改到存档
                coins -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];//减去对应价格的金币
                if(ButtonRef.GetComponent<ButtonInfo>().ItemID<=11){
                    buffLevel[ButtonRef.GetComponent<ButtonInfo>().ItemID-1]++;
                }
                Save();
                //重新显示金币数量
                coinsTxt.text = coins.ToString();
                shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++;
                //重新显示物品数量
                ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = "等级：" + shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString() + "/" + shopItems[4, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
            }
        }
    }

    public void Load()
    {
        data = SaveSystem.LoadFromJson<GameSave>("GameData.json");
        if(data == null){
            data = new GameSave();
            data.buffLevel = new int[20];
            for(int i = 0; i < GameManager.buffNum; i++){
                data.buffLevel[i] = 0;
            }
        }
        coins = data.money;
        for(int i = 0; i < GameManager.buffNum; i++){
            buffLevel[i] = data.buffLevel[i];
        }
    }

    public void Save()
    {
        data.money = coins;
        data.buffLevel = buffLevel;
        SaveSystem.SaveByJson("GameData.json", data);
    }
}
