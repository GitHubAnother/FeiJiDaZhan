using UnityEngine;

public enum EnemyType
{
    enemy_0,
    enemy_1,
    enemy_2
}

public class Enemy : MonoBehaviour
{
    #region +
    public float moveSpeed = 1f;
    public int hp = 10;
    public int score = 100;
    public float YDestroyPos = 1f;
    public GameObject bullet;
    public Transform bulletPos;
    public EnemyType type = EnemyType.enemy_0;
    #endregion

    #region  Unity内置方法
    void Start()
    {
        Create();
    }
    void Update()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

        if (transform.position.y <= YDestroyPos)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    #region -Create间隔创建子弹
    void Create()
    {
        if (this.type == EnemyType.enemy_1)
        {
            InvokeRepeating("InstantiateBullet", 0, 1.6f);
        }
        else if (this.type == EnemyType.enemy_2)
        {
            InvokeRepeating("InstantiateBullet", 0, 6f);
        }
    }
    #endregion

    #region 实例化
    void InstantiateBullet()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
    #endregion
}
