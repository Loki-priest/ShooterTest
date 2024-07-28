using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineBehaviour : MonoBehaviour
{
    public FinishLine finishLine;
    public Player player;


    private void OnEnable()
    {
        finishLine.OnBotReached += DamagePlayer;
    }

    private void OnDisable()
    {
        finishLine.OnBotReached -= DamagePlayer;
    }

    void DamagePlayer()
    {
        player.DamageMe();
    }






}
