using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameManager GM;
    [SerializeField] private AudioManager Audio;
    [SerializeField] private FadeUI scoreUI;
    [SerializeField] private FadeUI menuUI;
    [SerializeField] private FadeUI gameOverUI;
    [SerializeField] private FadeUI pausedUI;
    [SerializeField] private FadeUI creditsUI;
    [SerializeField] private FadeUI HighScoreUI;

    [SerializeField] private Score score;
    [SerializeField] private TextMeshProUGUI HighScoreText;
    [SerializeField] private TextMeshProUGUI HighScoreInGameText;
    [SerializeField] private TextMeshProUGUI ScoreText;

    public bool InMenu = false;


    void Start()
    {
        InMenu = true;
        GM = FindObjectOfType<GameManager>();
        Audio = FindObjectOfType<AudioManager>();
        score = FindObjectOfType<Score>();
        menuUI.FadeIn(true);
        scoreUI.FadeOut(true);
        HighScoreUI.FadeOut(true);
        creditsUI.FadeOut(true);
        pausedUI.FadeOut(true);
        gameOverUI.FadeOut(true);
    }

    public void OnGameStart()
    {
        score.ResetScore();
        InMenu = false;
        HighScoreUI.FadeOut(false);
        menuUI.FadeOut(false);
        scoreUI.FadeIn(false);
        pausedUI.FadeOut(false);
        gameOverUI.FadeOut(false);
        creditsUI.FadeOut(false);
    }
    public void ShowMenu()
    {
        InMenu = true;
        menuUI.FadeIn(false);
        scoreUI.FadeOut(false);
        pausedUI.FadeOut(false);
        gameOverUI.FadeOut(false);
        HighScoreUI.FadeOut(false);
        creditsUI.FadeOut(false);
    }
    public void ShowGameOver()
    {
        score.UpdateScore();
        HighScoreText.text = score.HighScore.ToString();
        HighScoreInGameText.text = score.HighScore.ToString();
        ScoreText.text = score.score.ToString();
        InMenu = true;
        gameOverUI.FadeIn(false);
    }
    public void Paused(bool pause)
    {
        if (pause)
        {
            pausedUI.FadeIn(true);
            Time.timeScale = 0;
        }
        else if (!pause)
        {
            Time.timeScale = 1;
            pausedUI.FadeOut(false);
        }
    }
    public void Credits()
    {
        pausedUI.FadeOut(true);
        scoreUI.FadeOut(false);
        menuUI.FadeOut(false);
        gameOverUI.FadeOut(false);
        creditsUI.FadeIn(false);
        HighScoreUI.FadeOut(false);
    }
    public void HighScore()
    {
        pausedUI.FadeOut(true);
        scoreUI.FadeOut(false);
        menuUI.FadeOut(false);
        gameOverUI.FadeOut(false);
        creditsUI.FadeOut(false);
        HighScoreUI.FadeIn(false);
    }
    #region UI SOUND
    public void OnMouseClick()
    {

    }
    #endregion
}