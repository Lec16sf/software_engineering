using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int money = 0;
    public static int score = 0;
    public bool gameHasEnded = false;
    public float restartDelay = 4f;
    public GameObject PassPanel;
    public GameObject DeathPanel;
    public static int buffNum = 12;
    public int[] buffLevel = new int[20];
    private System.Random random = new System.Random();
    public Player player;
    public static string[] BuffText = new string[] { "子弹速度+10", "子弹射击间隔-10%", "子弹耐久+1", "子弹数量+1", "血量提高", "血量倍增", "横向速度+5", "伤害倍率+20%", "暴击率+5%", "暴击伤害+30%", "撞击免伤", "子弹吸血"};
    public float damage;
    public float speed = 20f;
    public float bulletIntervalReduceRate = 1f;
    public int endurance = 1;
    public int bulletNum = 1;
    public float sidewaysForce = 10f;
    public float damageEnhanceRate = 1f;
    public float criticalHitRate = 0f;
    public float criticalHitEnhanceRate  = 1f;
    public float damageReductionRate = 0f;
    public float vampireRate = 0f;
    public GameObject ChestMenuUI;
    public static int[] ChextBuffIndexs = new int [3];
    public GameSave data;

    public void Start()
    {
        Load();
        player = GameObject.FindObjectOfType<Player>();
    }

    public void Load(){
        data = SaveSystem.LoadFromJson<GameSave>("GameData.json");
        if(data == null){
            data = new GameSave();
            data.buffLevel = new int[20];
            for(int i = 0; i < buffNum; i++){
                data.buffLevel[i] = 0;
            }
        }
        money = data.money;
        for(int i = 0; i < buffNum; i++){
            while(buffLevel[i]<data.buffLevel[i]){
                getBuff(i);
            }
        }
    }

    public void Save(){
        data.money = money;
        SaveSystem.SaveByJson("GameData.json", data);
    }

    public void Complete()
    {
        PassPanel.SetActive(true);
        Time.timeScale = 0f;
        Save();
    }

    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            DeathPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void getBuff(int index)
    {
        Debug.Log("getbuff" +index);
        switch (index)
        {
            case 0:
                buffLevel[0]++;
                speed += 10;
                break;
            case 1:
                buffLevel[1]++;
                bulletIntervalReduceRate *= 0.9f;
                break;
            case 2:
                buffLevel[2]++;
                endurance++;
                break;
            case 3:
                buffLevel[3]++;
                bulletNum+=2;
                break;
            case 4:
                buffLevel[4]++;
                double random1 = random.NextDouble()*500;
                player.health += (float)random1;
                break;
            case 5:
                buffLevel[5]++;
                double random2 = random.NextDouble()+1.5;
                player.health *= (float)random2;
                break;
            case 6:
                buffLevel[6]++;
                sidewaysForce += 5;
                break;
            case 7:
                buffLevel[7]++;
                damageEnhanceRate += 0.2f;
                break;
            case 8:
                buffLevel[8]++;
                criticalHitRate += 0.05f;
                break;
            case 9:
                buffLevel[9]++;
                criticalHitEnhanceRate += 0.3f;
                break;
            case 10:
                buffLevel[10]++;
                if(buffLevel[10] == 1){
                    damageReductionRate += 0.1f;
                }else{
                    damageReductionRate += 0.2f;
                }
                break;
            case 11:
                buffLevel[11]++;
                if(buffLevel[11] == 1){
                    vampireRate += 0.04f;
                }else{
                    vampireRate += 0.03f;
                }
                break;
            default:
                break;
        }
    }

    public void getBuff()
    {
        ChestMenuUI.SetActive(true);
        int i=0;
        foreach (Transform child in ChestMenuUI.transform)
        {
            ChextBuffIndexs[i] = getBuffNum();
            TextMeshProUGUI[] textComponents = child.GetComponentsInChildren<TextMeshProUGUI>();
            foreach (TextMeshProUGUI textComponent in textComponents)
            {
                if (textComponent != null && textComponent.name == "Text (TMP)")
                {
                    textComponent.text = BuffText[ChextBuffIndexs[i]];
                }
            }
            Image[] imageComponents = child.GetComponentsInChildren<Image>();
            foreach (Image imageComponent in imageComponents)
            {
                if (imageComponent != null && imageComponent.transform.parent == child)
                {
                    string spritePath = "BuffIcons/" + ChextBuffIndexs[i];
                    Debug.Log("Attempting to load sprite from path: " + spritePath);
                    Sprite newSprite = Resources.Load<Sprite>(spritePath);
                    if (newSprite != null)
                    {
                        imageComponent.sprite = newSprite;
                    }
                    else
                    {
                        Debug.LogError("Failed to load sprite: " + spritePath);
                    }
                }
            }
            i++;
        }
        PauseMenu.GameIsPaused = true;
        Time.timeScale = 0f;
    }

    public int getBuffNum()
    {
        int randomNum = random.Next(0, buffNum);
        if(randomNum == 3 && buffLevel[3] > 2){
            return getBuffNum();
        }
        if(randomNum == 10 && buffLevel[10] > 2){
            return getBuffNum();
        }
        if(randomNum == 11 && buffLevel[11] > 2){
            return getBuffNum();
        }
        return randomNum;
    }

    public void LeftButton()
    {
        getBuff(GameManager.ChextBuffIndexs[0]);
        PauseMenu.GameIsPaused = false;
        Time.timeScale = 1f;
        ChestMenuUI.SetActive(false);
    }
    public void MidButton()
    {
        getBuff(GameManager.ChextBuffIndexs[1]);
        PauseMenu.GameIsPaused = false;
        Time.timeScale = 1f;
        ChestMenuUI.SetActive(false);
    }
    public void RightButton()
    {
        getBuff(GameManager.ChextBuffIndexs[2]);
        PauseMenu.GameIsPaused = false;
        Time.timeScale = 1f;
        ChestMenuUI.SetActive(false);
    }
}