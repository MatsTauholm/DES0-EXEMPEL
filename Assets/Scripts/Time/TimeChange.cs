using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeChange : MonoBehaviour
{

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Time.timeScale = 0.2f;
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            Time.timeScale = 1f;
        }
    }
}
