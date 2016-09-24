/*
作者名称:YHB

脚本作用:切换到游戏场景

建立时间:2016.9.24.14.40
*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGameBtn : MonoBehaviour
{
    public void LoadPlayGameScene()
    {
        SceneManager.LoadScene(1);
    }
}
