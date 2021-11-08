using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Manager manager;
    Spawner spawn;
    public float health = 50f;
    private bool isDead = false;
    public Enemy enemy;


    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<Manager>();
        spawn = manager.GetComponentInChildren<Spawner>();

        enemy = GetComponent<Enemy>();
    }

    void Update() {
    }

    public void TakeDamage(float amount) {
        health -= amount;

        if (health <= 0f) {
            Die();
        }
    }

    public void Die() {

        isDead = true;
        enemy.EnemyDieAnim();            
        spawn.enemiesKilled++;
        manager.AddScorePoints();
        Destroy(gameObject, 5);


        if(spawn.enemiesKilled >= spawn.spawnAmount)
        {
            spawn.NextWave();
        }       
    }

    public bool GetIsDead()
    {
        return isDead;
    }

    public void SetDead(bool dead)
    {
        isDead = dead;
    }

    public Enemy GetEnemy(Enemy enemy)
    {
        return enemy;
    }
}
