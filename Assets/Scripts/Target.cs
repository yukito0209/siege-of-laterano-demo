using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f; // 目标的生命值

    // 公开方法，用于让其他脚本调用来对该目标造成伤害
    public void TakeDamage(float amount)
    {
        health -= amount; // 减去伤害值
        Debug.Log(transform.name + " took " + amount + " damage. Health: " + health); // 打印伤害信息

        if (health <= 0f)
        {
            Die(); // 如果生命值耗尽，调用死亡方法
        }
    }

    void Die()
    {
        Debug.Log(transform.name + " died.");
        // 在这里可以添加死亡效果，比如销毁物体、播放动画、粒子效果等
        Destroy(gameObject); // 暂时先直接销毁该游戏对象
    }
}