using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private bool gameIsPaused = false;
    private GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = this.transform.GetChild(0).gameObject;
        pauseMenu.SetActive(false);     //make sure to turn off the pasue menu at strat.
    }

    // Update is called once per frame
    void Update()
    {
        // press escape to pasue or unpause the game
        if (Input.GetKeyDown(KeyCode.Escape)) PauseGame();
        {

        }
    }

    public void PauseGame ()
    {
        if(!gameIsPaused)
        {
            // the game is not paused, lets's pause.
            gameIsPaused = true;
            // show the pause menu
            pauseMenu.SetActive(true);
            // set timescale to zero
            Time.timeScale = 0;
        }
        else
        {
            gameIsPaused = false;
            pauseMenu.SetActive(false);
            // set timeScale to one
            Time.timeScale = 1;
        }
    }

    public void RestartGame()
    {
       
        // Reload the current scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
