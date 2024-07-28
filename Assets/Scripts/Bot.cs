using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bot : MonoBehaviour
{

    int maxHealth = 1;
    int health = 1;
    float speedMin;
    float speedMax;
    float speed = 1f;

    Rigidbody2D rb;

    public event Action<Bot> OnDeath;

    bool isDead = false;

    public void InitMe(GameSettings.EnemiesSettings botSettings)
    {
        health = maxHealth = botSettings.enemiesHealth;
        speedMin = botSettings.enemiesSpeedMin;
        speedMax = botSettings.enemiesSpeedMax;
    }


    public void RestartMe()
    {
        Start();
    }


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Start()
    {
        isDead = false;
        health = maxHealth;
        MoveMe();
    }


    void MoveMe()
    {
        speed = UnityEngine.Random.Range(speedMin, speedMax);
        rb.velocity = transform.up * speed;
    }


    public void DamageMe(int val)
    {
        health -= val;
        if (health <= 0)
        {
            KillMe();
        }
    }

    public void KillMe()
    {
        //todo particle1
        DestroyMe();
    }

    public void ReachLine()
    {
        //todo particle2
        DestroyMe();
    }

    void DestroyMe()
    {
        if (isDead)
            return;

        gameObject.SetActive(false);

        OnDeath?.Invoke(this);

        isDead = true;
    }



}
