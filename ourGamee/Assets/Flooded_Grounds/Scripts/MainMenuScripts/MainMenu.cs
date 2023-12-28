using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("hellooo");
        SceneManager.LoadScene("ourScene");

    }

    public void QuitGame()
    {
        Debug.Log("QUITT");
        Application.Quit();
    }
}
