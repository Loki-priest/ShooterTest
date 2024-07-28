using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FinishLine : MonoBehaviour
{

    public event Action OnBotReached;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody.TryGetComponent(out Bot bot))
        {
            OnBotReached?.Invoke();
            bot.ReachLine();
        }
    }





}
