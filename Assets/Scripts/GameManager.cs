using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 4f;
    public GameObject completeLevelUI;
    public int buffNum = 12;
    public int[] buffLevel = new int[100];
    private System.Random random = new System.Random();
    Player player;
    public static string[] BuffText = new string[] { "子弹速度+10", "子弹射击间隔-10%", "子弹耐久+1", "子弹数量+1", "血量+", "血量*", "横向速度+5", "伤害倍率+20%", "暴击率+5%", "暴击伤害+30%", "撞击免伤", "子弹吸血"};
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


    public void Start()
    {
        Clear();
        player = GameObject.FindObjectOfType<Player>();
    }

    public void FixedUpdate()
    {
    }

    public void Clear()
    {
        for (int i = 0; i < 21; i++)
        {
            buffLevel[i] = 0;
        }
        speed = 20f;
        bulletIntervalReduceRate = 1f;
        endurance = 1;
        bulletNum = 1;
        sidewaysForce = 10f;
        damageEnhanceRate = 1f;
        criticalHitRate = 0f;
        criticalHitEnhanceRate  = 1f;
        damageReductionRate = 0f;
        vampireRate = 0f;
    }

    public void Complete()
    {
        completeLevelUI.SetActive(true);
        Clear();
    }

    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        for (int i = 0; i < 21; i++)
        {
            buffLevel[i] = 0;
        }
    }

    public void getBuff(int index)
    {
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
                player.health += random.Next(10, 500);
                break;
            case 5:
                buffLevel[5]++;
                player.health *= random.Next(1, 2);
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
                damageReductionRate += 0.1f;
                break;
            case 11:
                buffLevel[11]++;
                vampireRate += 0.1f;
                break;
            default:
                break;
        }
    }

    public void getBuff()
    {
        //TODO
    }

    public int getBuffNum()
    {
        int randomNum = random.Next(1, buffNum);
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
}
