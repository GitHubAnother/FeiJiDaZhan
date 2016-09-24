using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum GameState
{
    Runing,
    Stoping
}

public class GameManager : MonoBehaviour
{
    public static GameManager _i;

    public GameState gameState = GameState.Runing;
    public int score = 0;
    public Text ScoreText;

    void Awake()
    {
        _i = this;
    }

    void Update()
    {
        ScoreText.text = "Score:" + score;
    }

}
