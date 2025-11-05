using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFade : MonoBehaviour
{
    private Light2D light2D;
    [SerializeField] float minIntensity = 0.5f;
    [SerializeField] float maxIntensity = 1.5f;
    [SerializeField] float fadeSpeed = 0.1f;

    private void Start()
    {
        if (light2D == null)
        {
            light2D = GetComponent<Light2D>();
        }
    }

    private void Update()
    {
        if (light2D != null)
        {
            light2D.intensity = Mathf.Lerp(minIntensity, maxIntensity, Mathf.PerlinNoise(Time.time * fadeSpeed, 0));
        }
    }
}