using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;

    public int score = 0;
    public int HighScore = 0;
    public void ScoreUpdate(int Score)
    {
        score += Score;
        UpdateScore();
        ScoreText.text = score.ToString();
    }
    public void UpdateScore()
    {
        if (score > HighScore)
        {
            HighScore = score;
            Debug.Log(HighScore);
        }
    }
    public void ResetScore()
    {
        score = 0;
        ScoreText.text = score.ToString();
    }
}
