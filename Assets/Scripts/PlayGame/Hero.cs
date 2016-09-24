using UnityEngine;

public class Hero : MonoBehaviour
{
    #region -
    private float superGunTime = 0f;
    private Gun gunTop = null;
    private Gun gunLeft = null;
    private Gun gunRigth = null;
    private float resetSuperGunTime = 10f;
    private int gunCount = 1;
    #endregion

    #region Unity内置方法
    void Start()
    {
        gunTop = this.transform.FindChild("Gun").GetComponent<Gun>();
        gunLeft = this.transform.FindChild("Gun_Left").GetComponent<Gun>();
        gunRigth = this.transform.FindChild("Gun_Right").GetComponent<Gun>();

        gunTop.openFire();
    }
    void Update()
    {
        Move();
        Shot();
    }
    #endregion

    #region -Move玩家飞机跟随鼠标移动适用于移动端
    void Move()
    {
        if (Input.GetMouseButton(0) && GameManager._i.gameState == GameState.Runing)
        {
            if (MousePositionToRay.MPSPToRay("Player"))
            {
                Vector3 offset = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                float x = Mathf.Clamp(offset.x, -2.1f, 2.1f);
                float y = Mathf.Clamp(offset.y, -3.6f, 3.65f);

                offset = new Vector3(x, y, 0);

                this.transform.position = offset;
            }
        }
    }
    #endregion

    #region -Shot发射子弹
    void Shot()
    {
        superGunTime -= Time.deltaTime;

        if (superGunTime > 0)
        {
            if (gunCount == 1)
            {
                transformToSuperGun();
            }
        }
        else if (superGunTime < 0)
        {
            if (gunCount == 2)
            {
                transformToNormalGun();
            }
        }
    }
    #endregion

    #region -transformToSuperGun
    void transformToSuperGun()
    {
        gunCount = 2;
        gunLeft.openFire();
        gunRigth.openFire();
    }
    #endregion

    #region -transformToNormalGun
    void transformToNormalGun()
    {
        gunCount = 1;
        gunLeft.stopFire();
        gunRigth.stopFire();
    }
    #endregion

    #region -OnTriggerEnter2D
    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.tag == "award")
        {
            Award a = hit.GetComponent<Award>();

            if (a.type == ItemType.GoldBullet)
            {
                superGunTime = resetSuperGunTime;
            }
            else if (a.type == ItemType.Bomb)
            {
                BombManager._i.AddBomb();
            }

            Destroy(hit.gameObject);
        }
        else if (hit.tag == "enemy" || hit.tag == "EnemyBullet")
        {
            gameOverManess._i.Show(GameManager._i.score);
            BombManager._i.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
    #endregion
}
