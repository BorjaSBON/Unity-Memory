using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject difficulties;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && difficulties.activeInHierarchy == true)
        {
            mainMenu.SetActive(true);
            difficulties.SetActive(false);
        }
    }

    public void goMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void playGame()
    {
        mainMenu.SetActive(false);
        difficulties.SetActive(true);
    }
    public void playGamePers()
    {
        SceneManager.LoadScene(2);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void Options()
    {
        SceneManager.LoadScene(1);
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

    public void Back()
    {
        mainMenu.SetActive(true);
        difficulties.SetActive(false);
    }
}
