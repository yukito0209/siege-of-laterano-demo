using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public float damage = 10f;         // 每次射击造成的伤害
    public float range = 100f;        // 射击的最大距离
    public Camera fpsCam;             // 对玩家摄像机的引用
    public GameObject impactEffectPrefab; // 对击中特效预制件的引用

    // Update is called once per frame
    void Update()
    {
        // 检测玩家是否按下了鼠标左键 (Fire1 是默认的鼠标左键/Ctrl键)
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot(); // 调用射击函数
        }
    }

    void Shoot()
    {
        // 创建一个射线，从摄像机中心向前发射
        RaycastHit hitInfo; // 用于存储射线击中物体的信息

        // Physics.Raycast() 发射射线并返回是否击中物体
        // 参数：射线起点 (摄像机位置), 射线方向 (摄像机前方), 输出击中信息, 射程
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo, range))
        {
            // 如果射线击中了物体
            Debug.Log("Hit: " + hitInfo.transform.name); // 在 Console 打印击中物体的名字

            // 尝试从被击中的物体上获取 Target 组件
            Target target = hitInfo.transform.GetComponent<Target>();
            if (target != null) // 检查是否成功获取到了 Target 组件 (即是否击中了可受伤害的目标)
            {
                // 调用目标身上的 TakeDamage 方法，传入伤害值
                target.TakeDamage(damage);
            }

            // --- 在这里添加击中特效 (后续步骤) ---
            if (impactEffectPrefab != null)
            {
                // Instantiate(预制件, 击中点位置, 旋转)
                // Quaternion.LookRotation(hitInfo.normal) 让特效大致面向击中表面的法线方向（即背离表面）
                Instantiate(impactEffectPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            }
        }
        else
        {
            // 如果射线没有击中任何东西 (射到了空中)
            // Debug.Log("Missed"); // 可以取消注释来调试
        }
    }
}