using UnityEngine;

public class MoveNegativeX : MonoBehaviour
{
    public float speed = -5.0f; // 设置初始速度，负值表示沿X轴负方向
    public float rotationSpeed = 100.0f; // 设置旋转速度
    public float startTime = 2.0f; // 设置计时器时间，单位为秒

    private bool hasStartedMoving = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("没有找到Rigidbody组件，请确保GameObject上附加了Rigidbody组件。");
        }
    }

    void Update()
    {
        if (!hasStartedMoving)
        {
            // 计时器
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
        // 给物体一个沿X轴负方向的初速度
        rb.velocity = new Vector3(speed, 0, 0);

        // 给物体一个旋转速度
        rb.angularVelocity = new Vector3(0, rotationSpeed, 0); // 绕Y轴旋转
    }
}