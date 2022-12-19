using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public ElementControl element1;
    public ElementControl element2;

    public int times;

    void Start()
    {
        times = 0;
    }


    void Update()
    {
        if(times == 2)
        {
            CheckImages();
        }
    }

    public void CheckImages()
    {
        if(element1.value == element2.value)
        {
            Destroy(element1, 1.0f);
            Destroy(element2, 1.0f);

            times = 0;
        } else
        {
            element1.front = false;
            element2.front = false;

            element1 = new ElementControl();
            element2 = new ElementControl();

            times = 0;
        }
    }
}
