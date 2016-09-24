using UnityEngine;

public class Spawn : MonoBehaviour
{
    #region +
    public GameObject enemy_0;
    public GameObject enemy_1;
    public GameObject enemy_2;
    public GameObject award_1;
    public GameObject award_2;
    #endregion


    #region 单例
    public static Spawn _i;

    void Awake()
    {
        _i = this;
    }
    #endregion

    #region 间隔固定时间生产一个敌人和道具
    void Start()
    {
        InvokeRepeating("enemy_0_Pre", 1f, 1f);
        InvokeRepeating("enemy_1_Pre", 5f, 9f);
        InvokeRepeating("enemy_2_Pre", 30f, 30f);
        InvokeRepeating("award_1_Pre", 10f, 16f);
        InvokeRepeating("award_2_Pre", 20f, 30f);
    }
    #endregion

    #region -敌人和道具位置的随机方法
    void enemy_0_Pre()
    {
        float x_pos = Random.Range(-2f, 2f);
        Instantiate(enemy_0, new Vector3(x_pos, transform.position.y, 0), Quaternion.identity);
    }
    void enemy_1_Pre()
    {
        float x_pos = Random.Range(-2f, 2f);
        Instantiate(enemy_1, new Vector3(x_pos, transform.position.y, 0), Quaternion.identity);
    }
    void enemy_2_Pre()
    {
        float x_pos = Random.Range(-1.6f, 1.6f);
        Instantiate(enemy_2, new Vector3(x_pos, transform.position.y, 0), Quaternion.identity);
    }
    void award_1_Pre()
    {
        float x_pos = Random.Range(-2.1f, 2.1f);
        Instantiate(award_1, new Vector3(x_pos, transform.position.y, 0), Quaternion.identity);
    }
    void award_2_Pre()
    {
        float x_pos = Random.Range(-2.1f, 2.1f);
        Instantiate(award_2, new Vector3(x_pos, transform.position.y, 0), Quaternion.identity);
    }
    #endregion

    #region 停止生产敌人和道具的方法
    public void StopCreate()
    {
        CancelInvoke("enemy_0_Pre");
        CancelInvoke("enemy_1_Pre");
        CancelInvoke("enemy_2_Pre");
        CancelInvoke("award_1_Pre");
        CancelInvoke("award_2_Pre");
    }
    #endregion
}
