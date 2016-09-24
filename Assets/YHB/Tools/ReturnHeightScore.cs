using UnityEngine;

public class ReturnHeightScore
{
    /// <summary>
    /// 返回本地存储的最高分数
    /// </summary>
    /// <param name="currentScore">一局游戏结束后的当前分数</param>
    /// <returns>本地最高得分</returns>
    public static string Score(float currentScore)
    {
        float height = PlayerPrefs.GetFloat("HeightScore");

        if (currentScore > height)
        {
            PlayerPrefs.SetFloat("HeightScore", currentScore);
        }

        return PlayerPrefs.GetFloat("HeightScore").ToString();
    }
}
