using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteLogic : MonoBehaviour
{
    public Manager manager;
    public Text remaining;
    public Text killed;
    public Text wave;

    public Target target;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        wave.text = "Wave: " + manager.GetWave().ToString();
        killed.text = "Killed: " + manager.GetZombiesKilled().ToString();
        remaining.text = "Remaining: " + manager.GetRemainingZombies().ToString();
        CheckIfDead();
    }

    void CheckIfDead()
    {
        if (target.GetIsDead())
        {
            target = null;
            manager.AddScore();
            target.SetDead(false);
        }
    }
}
