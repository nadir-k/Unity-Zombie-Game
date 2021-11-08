using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player single;
    [SerializeField]
    public float currentHealth;
    public float maxHealth = 100f;
    public Text healthText;

    public Text ScoreText;
    public Text HighScoreText;

    public Transform player;
    [SerializeField]
    public float xPos;
    [SerializeField]
    public float yPos;
    [SerializeField]
    public float zPos;

    private Vector3 position;
    public Quaternion rotation;

    public Manager manager;

    [SerializeField]
    public int score;
    [SerializeField]
    public int currentKilled;
    [SerializeField]
    public int remaining;
    [SerializeField]
    public int wave;

    public Gun rifle;
    public Gun pistol;

   [SerializeField]
   public int rifleCurrentAmmo;
   [SerializeField]
   public int pistolCurrentAmmo;

    public GameObject deathScreen;


    void Awake()
    {
        single = this;
    }

    void Start() {
        Time.timeScale = 1f;

        currentHealth = maxHealth;

        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<Manager>();
        player = GetComponent<Transform>();
        

    }

    void Update()
    {
        healthText.text = "Health: " + currentHealth.ToString();
        
        if(currentHealth <= 0)
        {
            deathScreen.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        GetX();
        GetY();
        GetZ();

        GetPos();
        GetRot();

        GetScore();
        GetCurrentKilled();
        GetRemaining();
        GetWave();

       // GetRifleName();
       // GetPistolName();
        GetRifleAmmo();
        GetPistolAmmo();


    }

    public Vector3 GetPos() {
        position = new Vector3(xPos, yPos, zPos);
        return position;
    }

    public void SetPos(Vector3 newPos) {
        position = newPos;
    }

    public Quaternion GetRot() {
        rotation = player.transform.rotation;
        return rotation;
    }

    public void SetRotation(Quaternion rotation)
    {
        this.rotation = rotation;
    }

    public void DamagePlayer(float damage)
    {
        currentHealth -= damage;
    }

   public float GetX()
    {
        xPos = player.transform.position.x;
        return xPos;
    }

    public float GetY()
    {
        yPos = player.transform.position.y;
        return yPos;
    }

    public float GetZ()
    {
        zPos = player.transform.position.z;
        return zPos;
    }

    public int GetScore() {
        score = manager.GetScore();
        return score;
    }

    /*public Transform GetPosition() {
        return player.transform.position;
    }*/

    public int GetCurrentKilled() {
        currentKilled = manager.GetZombiesKilled();
        return currentKilled;
    }

    public int GetRemaining() {
        remaining = manager.GetRemainingZombies();
        return remaining;
    }

    public int GetWave() {
        wave = manager.GetWave();
        return wave;
    }

    public int GetRifleAmmo() {
        rifleCurrentAmmo = rifle.GetCurrentAmmo();
        return rifleCurrentAmmo;
    }

    public int GetPistolAmmo()
    {
        pistolCurrentAmmo = pistol.GetCurrentAmmo();
        return pistolCurrentAmmo;
    }

    public void ScoreUpdate(int score)
    {
        ScoreText.text = score.ToString();
    }
    public void HighScoreUpdate(int Highscore)
    {
        HighScoreText.text = Highscore.ToString();
    }

}
