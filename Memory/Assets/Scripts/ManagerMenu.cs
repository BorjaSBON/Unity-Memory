using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
