using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GenerateGame : MonoBehaviour
{
    public GridLayoutGroup parent;
    public GameObject element;
    public GameObject victory;

    bool win = false;
    int reverse = 0;

    public int numImages;
    int[] values;
    int pairs;

    int index1;
    int index2;

    int value1;
    int value2;

    public TextMeshProUGUI pair;
    public TextMeshProUGUI punctuation;

    int restPairs;
    int punct = 0;
    int points = 5;

    public List<GameObject> elements;
    public Sprite[] spriteArray;
    public Sprite[] listImages;

    public GameObject discover;
    public Image imageElement;
    public TextMeshProUGUI nameElement;

    void Start()
    {
        numImages = SaveData.cards;
        discover.SetActive(false);

        CalculateRowsColumns();
        GetImages();
        GenerateObject();
        CheckPair();
    }

    void Update()
    {
        if (reverse < 2)
        {
            CheckValues();
        } else
        {
            if (parent.GetComponent<GridLayoutGroup>().enabled == true)
            {
                parent.GetComponent<GridLayoutGroup>().enabled = false;
            }

            StartCoroutine(Result());
        }
        CheckVictory();
    }

    // Initialize the dimensiones of the game
    public void CalculateRowsColumns()
    {
        if (numImages % 2 != 0)
        {
            numImages += 1;
        }

        if (numImages > 30)
        {
            numImages = 30;
        }
        else if (numImages < 4)
        {
            numImages = 4;
        }

        listImages = new Sprite[numImages/2];
        restPairs = numImages / 2 + 1;

        if (numImages >= 18)
        {
            parent.GetComponent<GridLayoutGroup>().constraintCount = 3;
        }

        pairs = numImages / 2;

        if (numImages < 10)
        {
            points = 5;
        } 
        else if (numImages >= 10 && numImages < 18)
        {
            points = 10;
        }
        else if (numImages >= 18 && numImages < 30)
        {
            points = 15;
        }
        else if (numImages >= 30)
        {
            points = 20;
        }
    }

    public void GetImages()
    {
        int begin = 0;
        int last = (int) (spriteArray.Length / (numImages / 2));

        for (int i=0; i<numImages/2; i++)
        {
            int random = UnityEngine.Random.Range(begin, last);
            listImages[i] = spriteArray[random];

            begin += (int)(spriteArray.Length / (numImages / 2));
            last += (int)(spriteArray.Length / (numImages / 2));
        }
    }

    public void GenerateObject()
    {
        for (int i=1; i<=numImages; i++)
        {
            GameObject newElement = Instantiate(element, parent.transform);
            elements.Add(newElement);
        }

        values = new int[numImages];

        for (int i=0; i<numImages/2; i++)
        {
            values[i * 2] = i + 1;
            values[i * 2 + 1] = i + 1;
        }

        for (int i=0; i<numImages; i++)
        {
            int rand = UnityEngine.Random.Range(0, values.Length-1);
            elements[i].GetComponent<ElementControl>().value = values[rand];
            elements[i].GetComponent<ElementControl>().frontImage = listImages[elements[i].GetComponent<ElementControl>().value-1];
            RemoveAt(ref values, rand);
        }
    }

    public void CheckValues()
    {
        int cardsTrue = 0;

        for (int i = 0; i < elements.Count; i++)
        {
            if (elements[i].GetComponent<ElementControl>().front == true)
            {
                if (index1 != i)
                {
                    if (reverse == 0)
                    {
                        index1 = i;
                        value1 = elements[i].GetComponent<ElementControl>().value;
                        reverse += 1;
                    }
                    else if (reverse == 1)
                    {
                        index2 = i; 
                        value2 = elements[i].GetComponent<ElementControl>().value;
                        reverse += 1;
                    }
                }
            }
            if (elements[i].gameObject.activeInHierarchy == false)
            {
                cardsTrue += 1;
            }
        }

        if (cardsTrue == elements.Count)
        {
            if (win == false)
            {
                SaveData.points += punct;
            }
            win = true;
        }
    }

    public void CheckEnableTrue()
    {
        for (int i = 0; i < elements.Count; i++)
        {
            if (elements[i].activeInHierarchy == true)
            {
                elements[i].GetComponent<ElementControl>().flip = false;
            }
        }
    }
    public void CheckEnableFalse()
    {
        for (int i = 0; i < elements.Count; i++)
        {
            if (elements[i].activeInHierarchy == true)
            {
                elements[i].GetComponent<ElementControl>().flip = true;
            }
        }
    }

    IEnumerator Result()
    {
        CheckEnableTrue();

        if (value1 == value2)
        {
            discover.SetActive(true);
            imageElement.sprite = elements[index1].GetComponent<ElementControl>().frontImage;
            String auxTxt = imageElement.sprite.ToString();
            nameElement.text = auxTxt.Split(" (")[0];
        }

        yield return new WaitForSecondsRealtime(1.5f);

        if (value1 == value2)
        {
            value1 = -1;
            value2 = -2;

            elements[index1].GetComponent<ElementControl>().front = false;
            elements[index2].GetComponent<ElementControl>().front = false;

            elements[index1].SetActive(false);
            elements[index2].SetActive(false);

            CheckPair();
            CheckPunctuation();

            discover.SetActive(false);
        }
        else
        {
            value1 = -1;
            value2 = -2;

            elements[index1].GetComponent<ElementControl>().front = false;
            elements[index2].GetComponent<ElementControl>().front = false;
        }

        CheckEnableFalse();
        reverse = 0;
    }

    public void CheckVictory()
    {
        if (win == true)
        {
            victory.gameObject.SetActive(true);
            Time.timeScale = 0.0F;
        }
    }

    public void CheckPair()
    {
        restPairs -= 1;
        pair.GetComponent<TextMeshProUGUI>().text = restPairs.ToString();
    }

    public void CheckPunctuation()
    {
        punct += points;
        punctuation.GetComponent<TextMeshProUGUI>().text = punct.ToString();
    }

    public static void RemoveAt<T>(ref T[] arr, int index)
    {
        for (int a = index; a < arr.Length - 1; a++)
        {
            arr[a] = arr[a + 1];
        }
        Array.Resize(ref arr, arr.Length - 1);
    }

    // Button to reset the scene
    public void ResetScene()
    {
        SceneManager.LoadScene(1);
    }
}
