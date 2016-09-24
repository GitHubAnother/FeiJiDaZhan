using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartStopBtn : MonoBehaviour
{
    public GameObject Z_T;//暂停游戏的背景
    public Sprite game_pause_nor;//暂停游戏图片
    public Sprite game_resume_nor;//开始游戏图片

    private Button Start_Stop_Btn;

    void Start()
    {
        Start_Stop_Btn = this.transform.FindChild("RunScene/Start_Stop_Btn").GetComponent<Button>();
    }

    public void RunGame()//暂停和开始游戏的按钮事件方法
    {
        if (GameManager._i.gameState == GameState.Runing)//转成暂停游戏状态
        {
            //更改按钮的图片
            Start_Stop_Btn.image.sprite = game_resume_nor;

            Time.timeScale = 0;
            Z_T.SetActive(true);
            GameManager._i.gameState = GameState.Stoping;
        }
        else if (GameManager._i.gameState == GameState.Stoping)
        {
            Start_Stop_Btn.image.sprite = game_pause_nor;

            Time.timeScale = 1;
            Z_T.SetActive(false);
            GameManager._i.gameState = GameState.Runing;
        }


    }
}
