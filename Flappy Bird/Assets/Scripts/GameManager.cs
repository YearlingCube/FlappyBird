using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager UI;
    [SerializeField] private AudioManager Audio;
    public GameObject Game;
    private Bird bird;
    public Transform tube1;
    public Transform tube2;
    public Transform tube3;

    public Transform birdReset;

    private bool pause = false;
    private void Start()
    {
        UI = FindObjectOfType<UIManager>();
        bird = FindObjectOfType<Bird>();
        Game.SetActive(false);
    }
    #region Buttons
    public void Play()
    {
        UI.OnGameStart();
        GameActive(true);
    }
    public void Credits()
    {
        UI.Credits();
    }
    public void HighScore()
    {
        UI.HighScore();
    }
    public void Pause()
    {
        if (pause)
            UI.Paused(true);
        else if (!pause)
            UI.Paused(false);
    }
    public void MainMenu()
    {
        Game.SetActive(false);
        UI.ShowMenu();
    }
    public void GameOver()
    {
        UI.ShowGameOver();
    }
    public void Retry()
    {
        bird.ResetBird();
        tube1.GetComponent<Tube>().ResetTube();
        tube2.GetComponent<Tube>().ResetTube();
        tube3.GetComponent<Tube>().ResetTube();
        UI.OnGameStart();
    }
    public void Quit()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    #endregion
    public void GameActive(bool active)
    {
        Game.SetActive(active);
    }
}
