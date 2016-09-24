using UnityEngine;

public class Gun : MonoBehaviour
{
    #region +
    public GameObject bullet;
    public float time = 0.2f;
    #endregion

    #region -fire具体的发射子弹的方法
    void fire()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
    #endregion

    #region  +openFire开始发射
    public void openFire()
    {
        InvokeRepeating("fire", 0.5f, time); //开启调用
    }
    #endregion

    #region  +stopFire停止发射
    public void stopFire()
    {
        CancelInvoke("fire");//取消调用
    }
    #endregion
}
