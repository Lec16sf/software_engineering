using UnityEngine;

public class FollowDragon : MonoBehaviour
{
    public Transform player;  // 玩家对象
    public Vector3 offset;   // 跟随玩家时的基本偏移量
    public float moveSpeed = 2.0f; // 左右移动的速度
    public float moveDistance = 0.5f; // 左右移动的最大距离

    // Update is called once per frame
    void Update()
    {
        // 计算左右移动的偏移量
        float sinValue = Mathf.Sin(Time.time * moveSpeed) * moveDistance;

        // 设置新的偏移量，仅在X轴上添加sinValue
        Vector3 newOffset = new Vector3(offset.x + sinValue, offset.y, offset.z);

        // 更新物体的位置
        transform.position = player.position + newOffset;
    }
}