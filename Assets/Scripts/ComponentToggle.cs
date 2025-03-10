using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentToggle : MonoBehaviour
{
    public Behaviour Component;
    public float ToggleTimer = 1f;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);

        if (Component)
        {
            while (true)
            {
                // Flip the enabled state.
                Component.enabled = !Component.enabled;

                // Wait for specified period before toggling again.
                yield return new WaitForSeconds(ToggleTimer);
            }
        }
    }
}
