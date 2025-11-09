using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    private float spawnerTimer;

    [SerializeField] GameObject spawnPoint;

    public Wave[] waves;

    public int currentWaveIndex = 0;



    void Start()
    {
       for (int i = 0; i < waves.Length; i++)
       {
            waves[i].enemiesLeft = waves[i].enemies.Length;
       }

    }

    void Update()
    {
        spawnerTimer -= Time.deltaTime;

        if (spawnerTimer <= 0)
        {
            spawnerTimer = waves[currentWaveIndex].waveInterval;
            StartCoroutine(SpawnWave());
        }

    }


    private IEnumerator SpawnWave()
    {
        for (int i = 0; i < waves[currentWaveIndex].enemies.Length; i++)
        {
            // Using casting to GameObject to avoid ambiguity
            GameObject enemyClone = (GameObject)Instantiate (waves[currentWaveIndex].enemies[i], spawnPoint.transform.position, Quaternion.identity);

            EnemyController enemy = enemyClone.GetComponent<EnemyController>();

            if (enemy != null)
            {
                //Debug.Log("Spawned enemy: " + enemyClone.name);
            }
            else
            {
                Debug.LogWarning("Spawned object does not have an EnemyController component!");
            }

            yield return new WaitForSeconds(waves[currentWaveIndex].spawnInterval);
        }
    }

    [System.Serializable]

    public class Wave
    {
        public GameObject[] enemies;
        public float spawnInterval;
        public float waveInterval;

        [HideInInspector] public int enemiesLeft;
    }


}
