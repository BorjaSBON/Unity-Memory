using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerMenu : MonoBehaviour
{
    public GameObject menu;

    void Start()
    {
        Time.timeScale = 1.0F;
        menu.SetActive(false);
    }

    void Update()
    {
        // Open Menu of the Game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1.0F)
            {
                Time.timeScale = 0.0F;
                menu.SetActive(true);
            } else
            {
                Time.timeScale = 1.0F;
                menu.SetActive(false);
            }
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0F;
        menu.SetActive(false);
    }

    public void PlayEasy()
    {
        SceneManager.LoadScene(4);
    }

    public void PlayMedium()
    {
        SceneManager.LoadScene(5);
    }

    public void PlayHard()
    {
        SceneManager.LoadScene(6);
    }

    public void PlayTemplate()
    {
        SceneManager.LoadScene(3);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
