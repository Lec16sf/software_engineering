using UnityEngine;

public class FollowDragon : MonoBehaviour
{
    public Transform player;  // ��Ҷ���
    public Vector3 offset;   // �������ʱ�Ļ���ƫ����
    public float moveSpeed = 2.0f; // �����ƶ����ٶ�
    public float moveDistance = 0.5f; // �����ƶ���������

    // Update is called once per frame
    void Update()
    {
        // ���������ƶ���ƫ����
        float sinValue = Mathf.Sin(Time.time * moveSpeed) * moveDistance;

        // �����µ�ƫ����������X�������sinValue
        Vector3 newOffset = new Vector3(offset.x + sinValue, offset.y, offset.z);

        // ���������λ��
        transform.position = player.position + newOffset;
    }
}