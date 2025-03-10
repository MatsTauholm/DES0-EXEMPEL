using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeChange : MonoBehaviour
{
    float defaultFixedDeltaTime;
    void Start()
    {
        defaultFixedDeltaTime = Time.fixedDeltaTime;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Time.timeScale = 0.2f;
            Time.fixedDeltaTime = defaultFixedDeltaTime * Time.timeScale;
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            Time.timeScale = 1f;
        }
    }
}
