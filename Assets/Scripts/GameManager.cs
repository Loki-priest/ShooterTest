using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentSetting;
    public GameSettings[] gameSettings;

    public BotSpawner botSpawner;
    public Player player;


    private void Start()
    {
        StartNewGame();
    }

    public void StartNewGame()
    {
        Time.timeScale = 1.0f;

        GameSettings settings = gameSettings[currentSetting];
        player.InitMe(settings.playerSettings, settings.bulletSettings);
        botSpawner.InitMe(settings.spawnerSettings, settings.enemiesSettings);
    }


}
