using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering; //För att få tillgång till volymer
using UnityEngine.Rendering.Universal; //För att få tillgång till postprocess effekter

public class PoisonEffect : MonoBehaviour
{
    private Volume v;
    private ChromaticAberration chromaticAberration;
    private ColorAdjustments colorAdjustments;
    public float oscillationSpeed = 2f;
    private float x = 0;
    public float hueSpeed;

    private bool poisioned = false;

    void Start()
    {
        v = GetComponent<Volume>();
        v.profile.TryGet(out chromaticAberration); //Referenser till de specifika effekterna
        v.profile.TryGet(out colorAdjustments);
    }

    void Update()
    {
        if (poisioned)
        {
            float oscillatingValue = Mathf.Sin(Time.time * oscillationSpeed) * 0.5f + 0.5f; //Matematiskformel för att värdet ska loopa mellan 0-1)
            chromaticAberration.intensity.value = oscillatingValue;
            colorAdjustments.postExposure.value = oscillatingValue;

            //Hueshift går från 0-180, sedan vill jag att den ska gå tillbaka till 0 igen för att få "bäst" effekt
            if (x <= 180)
            {
                colorAdjustments.hueShift.value = x;
                x += Time.deltaTime * hueSpeed;
            }
            else
            { x = 0; }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        { 
            poisioned = true;
            Debug.Log("Player is poisoned!");
        }
    }
}
