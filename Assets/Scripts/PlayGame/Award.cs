using UnityEngine;
using System.Collections;

#region 道具类型枚举
public enum ItemType
{
    Bomb,//炸弹
    GoldBullet//增强子弹的威力
}
#endregion

public class Award : MonoBehaviour
{
    public ItemType type;
    public const float moveSpeed = 1f;

    void Update()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

        if (this.transform.position.y <= -4.6f)
        {
            Destroy(gameObject);
        }
    }
}
