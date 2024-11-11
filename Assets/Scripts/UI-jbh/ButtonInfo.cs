using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    public int ItemID;
    public Text PriceTxt;
    public Text QuantityTxt;
    public GameObject ShopManager;

    // Update is called once per frame
    void Start()
    {
        PriceTxt.text = "价格：" + ShopManager.GetComponent<ShopManagerScript>().shopItems[2, ItemID].ToString();
        QuantityTxt.text = "等级：" + ShopManager.GetComponent<ShopManagerScript>().shopItems[3, ItemID].ToString() + "/" + ShopManager.GetComponent<ShopManagerScript>().shopItems[4, ItemID].ToString();
    }

    void Update()
    {
        PriceTxt.text = "价格：" + ShopManager.GetComponent<ShopManagerScript>().shopItems[2, ItemID].ToString();
        QuantityTxt.text = "等级：" + ShopManager.GetComponent<ShopManagerScript>().shopItems[3, ItemID].ToString() + "/" + ShopManager.GetComponent<ShopManagerScript>().shopItems[4, ItemID].ToString();
    }
}
