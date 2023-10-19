using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgr : MonoBehaviour
{
  public void LoadScene(string sceneName = "Main Menu")
    {
        SceneManager.LoadScene(sceneName);
    }

    // overloading methods.
    public void LoadScene(int buildIndex = 0)
    {
        SceneManager.LoadScene(buildIndex);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    public void RestartGame()
    {
        // To restart the game, you can load the scene with the current build index.
        int currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneBuildIndex);
    }
}
