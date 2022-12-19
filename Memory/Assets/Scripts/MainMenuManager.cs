using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public TMP_InputField input;
    public TextMeshProUGUI points;

    public void Start()
    {
        points.text = SaveData.points.ToString();
    }

    public void Update()
    {

    }

    public void LoadGame()
    {
        SaveData.cards = int.Parse(input.text);
        SceneManager.LoadScene(2);
    }
}
