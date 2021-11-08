using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Manager manager;
    public GameObject[] spawners;
    public GameObject enemy;
    public Target target;

    private int wave = 0;
    public int spawnAmount = 0;
    private int score = 0;
    public int enemiesKilled = 0;

    private float xPos;
    private float yPos;
    private float zPos;


    private Transform p;

    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<Target>();
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<Manager>();
        spawners = new GameObject[4];

        for(int i = 0; i < spawners.Length; i++)
        {
            spawners[i] = transform.GetChild(i).gameObject; 
        }

        StartWave();
    }

    private void SpawnEnemies()
    {
        int spawnerID = Random.Range(0, spawners.Length);
        Instantiate(enemy, spawners[spawnerID].transform.position, spawners[spawnerID].transform.rotation);
    }


    private void Update()
    {
        if (enemiesKilled >= spawnAmount)
        {
            NextWave();
        }
    }


    private void StartWave() {
        wave = 1;
        spawnAmount = 2;
        enemiesKilled = 0;
        manager.SetRemainingZombies(spawnAmount);
        manager.SetKilledZombies(enemiesKilled);
        manager.SetWave(wave);

        for(int i = 0; i < spawnAmount; i++)
        {
            SpawnEnemies();
        }
    }

    public void NextWave() {
        wave++;
        spawnAmount += 2;
        enemiesKilled = 0;
        manager.SetRemainingZombies(spawnAmount);
        manager.SetKilledZombies(enemiesKilled);
        manager.SetWave(wave);

        for (int i = 0; i < spawnAmount; i++)
        {
            SpawnEnemies();
        }
    }
}
