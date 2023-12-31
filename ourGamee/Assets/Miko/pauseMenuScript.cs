using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenu;

    public bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("game paused");
            pauseMenu.SetActive(true);
            isPaused = true;
            Time.timeScale = 0f; // pauses the game

        }
        if (isPaused == true & Input.GetKeyDown(KeyCode.R))
        {
            ResumeGame();
        }
        if (isPaused == true & Input.GetKeyDown(KeyCode.X))
        {
            RestartGame();
        }
        if (isPaused == true & Input.GetKeyDown(KeyCode.M))
        {
            ReturnToMain();
        }

    }

    public void ResumeGame()
    {
        Debug.Log("ji");
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f; //this plays the game

    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1); //n call el scene ml awal
        isPaused = false;
        pauseMenu.SetActive(false);
    }
    public void ReturnToMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // call main menu
        isPaused = false;

    }




}