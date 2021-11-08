using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public void ButtonHandlerIndustrial() {
        SceneManager.LoadScene(3);
    }

    public void ButtonHandlerForest() {
        SceneManager.LoadScene(4);
    }

    public void ButtonHandlerMainMenu() {
        SceneManager.LoadScene(0);
    }
}
