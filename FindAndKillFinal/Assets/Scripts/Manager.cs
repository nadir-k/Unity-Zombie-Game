using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private int zombiesKilled;
    private int zombiesRemaining;
    private int score;
    private int wave;

    public int pointScore;
    public int pointHighScore;


    // Start is called before the first frame update
    void Start()
    {
        zombiesKilled = 0;
        Player.single.HighScoreUpdate(PlayerPrefs.GetInt("HighScore", pointHighScore)); 
        Player.single.HighScoreUpdate(pointHighScore);
    }

    private void Update()
    {
        AddHighScorePoints();
        Player.single.ScoreUpdate(pointScore);
        Player.single.HighScoreUpdate(PlayerPrefs.GetInt("HighScore", pointHighScore));
    }

    public void SetRemainingZombies(int amount)
    {
        zombiesRemaining = amount;

    }

    public int GetRemainingZombies()
    {
        return zombiesRemaining;
    }

    public void AddScore()
    {        
        
        zombiesKilled++;
        score++;
        AddScorePoints();
        zombiesRemaining--;
    }

    public int GetZombiesKilled()
    {
        return zombiesKilled;
    }

    public void SetKilledZombies(int amount)
    {
        zombiesKilled = amount;
    }

    public void SetScore(int amount)
    {
        score = amount;
    }

    public int GetScore() {
        return score;
    }

    public int GetWave()
    {
        return wave;
    }

    public void SetWave(int amount)
    {
        wave = amount;
    }
    public void AddScorePoints()
    {
        pointScore += 100;
    }
    public void AddHighScorePoints()
    {
        if (pointScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", pointScore);
            pointHighScore = pointScore;

        }
    }

}
