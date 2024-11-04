using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering; //För att få tillgång till volymer
using UnityEngine.Rendering.Universal; //För att få tillgång till postprocess effekter

public class PoisonEffect : MonoBehaviour
{
    Volume v; //Deklaration av volymen
    ChromaticAberration chromaticAberration; //Deklaration av specifika effekter
    ColorAdjustments colorAdjustments;

    [SerializeField] float oscillationSpeed = 2f;
    [SerializeField] float hueSpeed;

    float x = 0;
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
            float oscillatingValue = Mathf.Sin(Time.time * oscillationSpeed) * 0.5f + 0.5f; //Matematiskformel för att loopa värdet mellan 0-1)
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        { 
            poisioned = true;
            Debug.Log("Player is poisoned!");
        }
    }
}
