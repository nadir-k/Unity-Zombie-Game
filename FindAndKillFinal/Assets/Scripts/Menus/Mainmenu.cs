using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public void SetVolume(float volume)
    {
        Debug.Log(volume);
    }
    public void ButtonHandlerMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ButtonHandlerNewGame() {
        SceneManager.LoadScene(1);
    }

    public void ButtonHandlerLoadGame() {
        SceneManager.LoadScene(2);
    }
    public void ButtonHandlerRetryGame()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex) ;
    }

    public void ButtonHandlerSettings() { 
    }

    public void ButtonHandlerQuit() {
        if (Application.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        } else
        {
            Application.Quit();
        }
    }
}
