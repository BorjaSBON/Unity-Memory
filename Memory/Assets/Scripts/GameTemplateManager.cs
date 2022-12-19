using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameTemplateManager : MonoBehaviour
{
    bool win = false;
    int reverse = 0;

    int index1;
    int index2;

    int value1;
    int value2;

    public List<GameObject> elements = new List<GameObject>(10);
    public GameObject victory;

    public TextMeshProUGUI pair;
    public TextMeshProUGUI punctuation;

    public int points;
    int restPairs;
    int punct = 0;

    public GameObject discover;
    public Image imageElement;
    public TextMeshProUGUI nameElement;

    void Start()
    {
        restPairs = elements.Count / 2 + 1;
        CheckPair();
        discover.SetActive(false);
    }

    void Update()
    {
        if (reverse < 2)
        {
            CheckValues();
        }
        else
        {
            StartCoroutine(Result());
        }

        CheckVictory();
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

    /*public void CheckElements()
    {
        if (element1.GetComponent<ElementControl>().front == true)
        {
            if (reverse == 0)
            {
                check1 = element1;
            } else
            {
                check2 = element1;
            }
            reverse += 1;
        }
        if (element2.GetComponent<ElementControl>().front == true)
        {
            if (reverse == 0)
            {
                check1 = element2;
            }
            else
            {
                check2 = element2;
            }
            reverse += 1;
        }
        if (element3.GetComponent<ElementControl>().front == true)
        {
            if (reverse == 0)
            {
                check1 = element3;
            }
            else
            {
                check2 = element3;
            }
            reverse += 1;
        }
        if (element4.GetComponent<ElementControl>().front == true)
        {
            if (reverse == 0)
            {
                check1 = element4;
            }
            else
            {
                check2 = element4;
            }
            reverse += 1;
        }
        if (element5.GetComponent<ElementControl>().front == true)
        {
            if (reverse == 0)
            {
                check1 = element5;
            }
            else
            {
                check2 = element5;
            }
            reverse += 1;
        }
        if (element6.GetComponent<ElementControl>().front == true)
        {
            if (reverse == 0)
            {
                check1 = element6;
            }
            else
            {
                check2 = element6;
            }
            reverse += 1;
        }
        if (element7.GetComponent<ElementControl>().front == true)
        {
            if (reverse == 0)
            {
                check1 = element7;
            }
            else
            {
                check2 = element7;
            }
            reverse += 1;
        }
        if (element8.GetComponent<ElementControl>().front == true)
        {
            if (reverse == 0)
            {
                check1 = element8;
            }
            else
            {
                check2 = element8;
            }
            reverse += 1;
        }
    }*/

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
}
