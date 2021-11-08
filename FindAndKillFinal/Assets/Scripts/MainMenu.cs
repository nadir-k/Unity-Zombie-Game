using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() {
       
    }

    public void QuitGame() {
        Debug.Log("quit");
        Application.Quit();
    }

    public void IndustrialLevelLoad() {
        SceneManager.LoadSceneAsync(1);
    }

    public void DesertLevelLoad() {
        SceneManager.LoadSceneAsync(2);
    }
}
