using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotsBehaviour : MonoBehaviour
{
    public BotSpawner spawner;
    public GUIManager gui;

    private void OnEnable()
    {
        spawner.OnScoreChanged += ShowScore;
        spawner.OnBotsOver += ShowWin;
    }

    private void OnDisable()
    {
        spawner.OnScoreChanged -= ShowScore;
        spawner.OnBotsOver -= ShowWin;
    }

    void ShowScore(int score)
    {
        gui.ShowScore(score);
    }

    void ShowWin() //all bots dead
    {
        Time.timeScale = 0.0f;
        gui.ShowGameOver(true);
    }

}
