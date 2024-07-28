using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Player player;
    public GUIManager gui;

    private void OnEnable()
    {
        player.OnHealthChanged += ShowHealth;
        player.OnDeath += ShowLose;
    }

    private void OnDisable()
    {
        player.OnHealthChanged -= ShowHealth;
        player.OnDeath -= ShowLose;
    }

    void ShowHealth(int health)
    {
        gui.ShowHealth(health);
    }

    void ShowLose() //player hp = 0
    {
        Time.timeScale = 0.0f;
        gui.ShowGameOver(false);
    }



}
