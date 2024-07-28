using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BotSpawner : MonoBehaviour
{

    public Transform[] spawnPoses;

    float spawnCDMin;
    float spawnCDMax;

    int botsLeft = 10;


    int score
    {
        get { return _score; }
        set { _score = value; OnScoreChanged?.Invoke(_score); }
    }
    int _score;

    float spawnTimer;

    Factory factory;

    public Transform botsPool;


    public event Action<int> OnScoreChanged;
    public event Action OnBotsOver;

    public void InitMe(GameSettings.SpawnerSettings _spawnerSettings, GameSettings.EnemiesSettings _botSettings)
    {
        botsLeft = UnityEngine.Random.Range(_spawnerSettings.enemiesAmountMin, _spawnerSettings.enemiesAmountMax + 1);
        spawnCDMin = _spawnerSettings.enemiesSpawnrateMin;
        spawnCDMax = _spawnerSettings.enemiesSpawnrateMax;

        factory = new BotFactory(_botSettings);

        score = botsLeft;
    }


    private void Update()
    {
        if (botsLeft == 0)
            return;

        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0.0f)
        {
            SpawnBot();
            botsLeft--;
            spawnTimer = UnityEngine.Random.Range(spawnCDMin, spawnCDMax);
        }
    }

    void SpawnBot()
    {
        if (botsPool.childCount > 0)
        {
            Transform bot = botsPool.GetChild(0);
            bot.position = spawnPoses[UnityEngine.Random.Range(0, spawnPoses.Length)].position;
            bot.gameObject.SetActive(true);
            Bot botComponent = bot.GetComponent<Bot>();
            botComponent.RestartMe();
            botComponent.OnDeath += KillBot;
        }
        else
        {
            Bot bot = factory.CreateBot();
            bot.transform.position = spawnPoses[UnityEngine.Random.Range(0, spawnPoses.Length)].position;
            bot.gameObject.AddComponent<PoolOnDisable>().container = botsPool;
            bot.OnDeath += KillBot;
        }
    }

    void KillBot(Bot bot)
    {
        score--;

        if (score == 0)
            OnBotsOver?.Invoke();

        bot.OnDeath -= KillBot;
    }


}
