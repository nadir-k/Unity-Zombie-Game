using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;

    public GameObject pauseMenuUi;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isGamePaused){
                Resume();
            } else {
                Pause();
            }
        }
    }

    void Resume() {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void GoToMenu() {
        SceneManager.LoadScene(0);
    }

    void Pause() {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }
    public void ButtonHandlerRetryGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);

    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
