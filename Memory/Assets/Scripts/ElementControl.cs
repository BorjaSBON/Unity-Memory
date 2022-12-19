using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ElementControl : MonoBehaviour, IPointerClickHandler
{
    public Sprite frontImage;
    public Sprite backgroundImage;

    public int value;
    public bool front = false;

    public bool flip = true;

    void Update()
    {
        ChangeImage();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (front == false)
        {
            if (flip)
            {
                front = true;
            }
        }
    }

    public void ChangeImage()
    {
        if (front == true)
        {
            gameObject.GetComponent<Image>().sprite = frontImage;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = backgroundImage;
        }
    }
}
