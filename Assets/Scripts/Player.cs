using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    int _health = 2;
    int Health
    {
        get { return _health; }
        set { _health = value; OnHealthChanged?.Invoke(_health); }
    }


    float speed = 1f;
    float shootCD = 0.5f;
    float detectionRadius = 0.5f;

    float shootTimer = 0f;

    Bullet bulletPrefab;

    Rigidbody2D rb;

    Transform currentTarget;

    public Transform radiusMask;
    public Transform radius;

    GameSettings.BulletSettings bulletSettings;

    public Transform bulletsPool;


    public event Action<int> OnHealthChanged;
    public event Action OnDeath;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    public void InitMe(GameSettings.PlayerSettings _playerSettings, GameSettings.BulletSettings _bulletSettings)
    {
        //read settings
        Health = _playerSettings.playerHealth;
        speed = _playerSettings.playerSpeed;
        shootCD = _playerSettings.playerShootCooldown;
        detectionRadius = _playerSettings.playerShootDistance;

        shootTimer = shootCD;

        //player detection circle
        radiusMask.localScale = Vector3.one * detectionRadius * 2f;
        radius.localScale = Vector3.one * (detectionRadius * 2f + 0.15f);

        bulletSettings = _bulletSettings;
        bulletPrefab = _bulletSettings.bulletPrefab;
    }


    void Update()
    {
        if (Health > 0)
        {
            MoveMe();
            FindTarget();
            Shoot();
        }
    }

    void MoveMe()
    {
        Vector2 deltaMove = Vector2.zero;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            deltaMove.y += speed;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            deltaMove.x -= speed;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            deltaMove.x += speed;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            deltaMove.y -= speed;
        }

        rb.velocity = deltaMove;
    }


    

    void FindTarget()
    {
        Collider2D bot = Physics2D.OverlapCircle(transform.position, detectionRadius, LayerMask.GetMask("Bot"));
        if (bot != null && bot.attachedRigidbody != null)
        {
            currentTarget = bot.attachedRigidbody.transform;
        }
        else
        {
            currentTarget = null;
        }
    }


    void Shoot()
    {
        shootTimer -= Time.deltaTime;

        if (currentTarget == null)
            return;

        if (shootTimer <= 0.0f)
        {
            Quaternion lookAt = new Quaternion();
            lookAt.SetFromToRotation(Vector3.up, currentTarget.position - transform.position);
            SpawnBullet(lookAt);

            shootTimer = shootCD;
        }
    }

    void SpawnBullet(Quaternion lookAt)
    {
        if (bulletsPool.childCount > 0)
        {
            Transform bullet = bulletsPool.GetChild(0);
            bullet.position = transform.position;
            bullet.rotation = lookAt;
            bullet.gameObject.SetActive(true);
            bullet.GetComponent<Bullet>().RestartMe();
        }
        else
        {
            Bullet bullet = Instantiate(bulletPrefab, transform.position, lookAt);
            bullet.InitMe(bulletSettings);
            bullet.gameObject.AddComponent<PoolOnDisable>().container = bulletsPool;
        }
    }



    public void DamageMe()
    {
        Health--;
        if (Health <= 0)
        {
            OnDeath?.Invoke();
        }
    }





}
