using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    float speed = 1f;
    int damage = 1;

    Rigidbody2D rb;

    public void InitMe(GameSettings.BulletSettings _bulletSettings)
    {
        damage = _bulletSettings.playerShootDamage;
        speed = _bulletSettings.playerShootSpeed;
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
        MoveMe();
    }


    void MoveMe()
    {
        rb.velocity = transform.up * speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody != null && collision.attachedRigidbody.TryGetComponent(out Bot bot))
        {
            bot.DamageMe(damage);
        }

        gameObject.SetActive(false);
    }



}
