using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour
{
    #region 字段
    public bool IsSplit = false;//表示子弹分裂成多个圆形发射
    #endregion

    #region Unity内置函数
    void Update()
    {
        if (IsSplit)
        {
            this.transform.Translate(Vector3.down * Time.deltaTime);

            //子弹分裂射击方法
            InvokeRepeating("BulletSplit", 0.6f, 10);
        }
        else
        {
            //子弹向下运动
            this.transform.Translate(Vector3.down * 5.6f * Time.deltaTime);

            if (this.transform.position.y < -4.5f || this.transform.position.y > 4.5f || this.transform.position.x < -2.5f || this.transform.position.x > 2.5f)
            {
                Destroy(this.gameObject);
            }
        }
    }
    #endregion

    #region -BulletSplit子弹分裂发射方法
    void BulletSplit()
    {
        for (int i = 0; i < 8; i++)
        {
            GameObject go = Instantiate(this.gameObject, this.transform.position, Quaternion.Euler(0, 0, i * 45)) as GameObject;

            go.GetComponent<CircleCollider2D>().enabled = true;
            EnemyBullet eb = go.GetComponent<EnemyBullet>();
            eb.enabled = true;
            eb.IsSplit = false;
        }

        Destroy(this.gameObject);
    }
    #endregion

}
