using UnityEngine;
using UnityEngine.UI;

public class BombManager : MonoBehaviour
{
    #region -
    private Text bombText;
    private int count = 0;
    #endregion

    #region 单例和初始化赋值
    public static BombManager _i;

    void Awake()
    {
        _i = this;
        bombText = this.GetComponent<Text>();
        this.gameObject.SetActive(false);
    }
    #endregion

    #region  +AddBomb玩家吃到炸弹道具数量增加一个
    public void AddBomb()
    {
        this.gameObject.SetActive(true);
        count++;
        bombText.text = "X:" + count;
    }
    #endregion

    #region +FSBtnOnClick炸弹按钮的点击事件，消灭场景中所有存在敌人
    public void FSBtnOnClick()
    {
        if (this.count > 0)
        {
            FrameAnimation[] frameAnimations = GameObject.FindObjectsOfType<FrameAnimation>();
            Enemy[] enemys = GameObject.FindObjectsOfType<Enemy>();

            foreach (FrameAnimation fa in frameAnimations)
            {
                if (fa.gameObject.tag != "Player")
                {
                    fa.OnceDes = true;
                }
            }

            foreach (Enemy enemy in enemys)
            {
                GameManager._i.score += enemy.score;
            }

            UseABomb();
        }
    }
    #endregion

    #region -UseABomb点击炸弹按钮实现炸弹数量减少一个
    void UseABomb()
    {
        if (count > 0)
        {
            count--;
            bombText.text = "X:" + count;

            if (count <= 0)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
    #endregion
}
