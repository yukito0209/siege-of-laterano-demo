using UnityEngine;

[RequireComponent(typeof(CharacterController))] // 确保 Player 对象总是有 CharacterController 组件
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f; // 公开变量，可以在 Unity Inspector 中调整移动速度
    public float gravity = -9.81f; // 模拟重力
    public float mouseSensitivity = 100f; // 鼠标灵敏度，可在 Inspector 中调整
    public Transform playerCamera; // 对相机 Transform 的引用

    private CharacterController characterController;
    private Vector3 velocity; // 用于存储下落速度
    private float xRotation = 0f; // 用于存储垂直旋转角度

    void Start()
    {
        // 获取对 CharacterController 组件的引用
        characterController = GetComponent<CharacterController>();

        // 锁定鼠标光标到游戏窗口中央并隐藏
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // --- 处理玩家输入 ---
        // 获取水平 (A/D 或 左/右箭头) 和垂直 (W/S 或 上/下箭头) 输入
        float horizontalInput = Input.GetAxis("Horizontal"); // 返回 -1 到 1
        float verticalInput = Input.GetAxis("Vertical");   // 返回 -1 到 1

        // --- 计算移动方向 ---
        // 使用 transform.right 和 transform.forward 来获取相对于玩家当前朝向的右方和前方
        // 这确保了 "W" 总是向前移动，无论玩家朝向哪里
        Vector3 moveDirection = transform.right * horizontalInput + transform.forward * verticalInput;
        moveDirection.Normalize(); // 标准化向量，确保斜向移动速度不会过快

        // --- 应用移动 ---
        // 使用 CharacterController.Move() 来移动玩家
        // Time.deltaTime 确保移动速度与帧率无关
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

        // --- 处理重力 ---
        // 检查玩家是否在地面上 (CharacterController 会处理这个)
        if (characterController.isGrounded && velocity.y < 0)
        {
            // 如果在地面上且正在下落，将垂直速度重置为一个较小负值（防止瞬间离地）
            velocity.y = -2f;
        }

        // 应用重力加速度 (速度 = 加速度 * 时间)
        velocity.y += gravity * Time.deltaTime;

        // 应用垂直速度 (重力导致的下落)
        characterController.Move(velocity * Time.deltaTime);

        // 获取鼠标移动输入
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // 计算垂直旋转角度 (限制在 -90 到 90 度之间)
        xRotation -= mouseY; // 减去 mouseY 是因为鼠标向上移动对应负 Y 值，但我们想让视角向上转
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp 限制角度范围

        // 应用垂直旋转到相机
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // 应用水平旋转到整个 Player 对象
        transform.Rotate(Vector3.up * mouseX);
    }
}