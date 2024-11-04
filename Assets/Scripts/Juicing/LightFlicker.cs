using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal; //Namespace for lightsettings

public class LightFlicker : MonoBehaviour
{
    public Light2D light2D;
    public float flickerIntervalMin = 0.05f;  // Minimum time between flickers
    public float flickerIntervalMax = 0.5f;   // Maximum time between flickers
    public float onIntensity = 1.5f;          // Light intensity when "on"
    public float offIntensity = 0.0f;         // Light intensity when "off"

    private float timer;

    private void Start()
    {
        if (light2D == null)
        {
            light2D = GetComponent<Light2D>();
        }
        timer = Random.Range(flickerIntervalMin, flickerIntervalMax);
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            // Toggle the light intensity between on and off
            if (light2D.intensity == onIntensity)
            { light2D.intensity = offIntensity; }
            else
            { light2D.intensity = onIntensity; }

            // Reset the timer to a new random interval
            timer = Random.Range(flickerIntervalMin, flickerIntervalMax);
        }
    }
}
