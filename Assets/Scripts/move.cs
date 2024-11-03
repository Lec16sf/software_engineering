using UnityEngine;

public class MoveNegativeX : MonoBehaviour
{
    public float speed = -5.0f; // ���ó�ʼ�ٶȣ���ֵ��ʾ��X�Ḻ����
    public float rotationSpeed = 100.0f; // ������ת�ٶ�
    public float startTime = 2.0f; // ���ü�ʱ��ʱ�䣬��λΪ��

    private bool hasStartedMoving = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("û���ҵ�Rigidbody�������ȷ��GameObject�ϸ�����Rigidbody�����");
        }
    }

    void Update()
    {
        if (!hasStartedMoving)
        {
            // ��ʱ��
            startTime -= Time.deltaTime;

            if (startTime <= 0)
            {
                StartMovement();
                hasStartedMoving = true;
            }
        }
    }

    void StartMovement()
    {
        // ������һ����X�Ḻ����ĳ��ٶ�
        rb.velocity = new Vector3(speed, 0, 0);

        // ������һ����ת�ٶ�
        rb.angularVelocity = new Vector3(0, rotationSpeed, 0); // ��Y����ת
    }
}