using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOverManess : MonoBehaviour
{
    public static gameOverManess _i;

    private Text heightScoreText;
    private Text currentScoreText;

    void Awake()
    {
        _i = this;
        heightScoreText = this.transform.FindChild("heightScore").GetComponent<Text>();
        currentScoreText = this.transform.FindChild("nowScore").GetComponent<Text>();
        this.gameObject.SetActive(false);
    }

    //供外部调用的死亡后显示最高分数和当前分数
    public void Show(float currentScore)
    {
        heightScoreText.text = ReturnHeightScore.Score(currentScore);
        currentScoreText.text = currentScore.ToString();

        Spawn._i.StopCreate();

        this.gameObject.SetActive(true);
    }

    public void OnReStartBtn()
    {
        SceneManager.LoadScene(1);
    }

    public void OnExitBtn()
    {
        Application.Quit();
    }
}
