using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[CreateAssetMenu()]
public class GameSettings : ScriptableObject
{

    [System.Serializable]
    public class SpawnerSettings
    {
        [Min(1)]
        public int enemiesAmountMin = 1;
        [Min(1)]
        public int enemiesAmountMax = 1;

        public float enemiesSpawnrateMin = 1.0f;
        public float enemiesSpawnrateMax = 1.0f;
    }

    [Header("Spawner")]
    public SpawnerSettings spawnerSettings;





    [System.Serializable]
    public class EnemiesSettings
    {
        public Bot botPrefab;

        public float enemiesSpeedMin = 1.0f;
        public float enemiesSpeedMax = 1.0f;

        [Min(1)]
        public int enemiesHealth = 1;
    }

    [Header("Enemies")]
    public EnemiesSettings enemiesSettings;





    [System.Serializable]
    public class PlayerSettings
    {
        [Min(1)]
        public int playerHealth = 1;
        public float playerSpeed = 1.0f;
        public float playerShootDistance = 1.0f;
        public float playerShootCooldown = 1.0f;
    }

    [Header("Player")]
    public PlayerSettings playerSettings;





    [System.Serializable]
    public class BulletSettings
    {
        public Bullet bulletPrefab;

        [Min(1)]
        public int playerShootDamage = 1;
        public float playerShootSpeed = 1.0f;
    }

    [Header("Bullets")]
    public BulletSettings bulletSettings;







    





   


   





}
