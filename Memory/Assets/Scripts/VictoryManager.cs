using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryManager : MonoBehaviour
{
    public GameObject timer;
    public GameObject victory;

    void Update()
    {
        if (victory.activeInHierarchy == true)
        {
            timer.GetComponent<CountUp>().timeActive = false;
        } 
        else
        {
            timer.GetComponent<CountUp>().timeActive = true;
        }
    }
}
