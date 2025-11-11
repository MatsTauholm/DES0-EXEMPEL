using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleBehavior : MonoBehaviour
{
    [SerializeField] Behaviour m_BehaviourComponent;
    [SerializeField] float m_TogglePeriod = 1f;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);

        if (m_BehaviourComponent)
        {
            while (true)
            {
                // Flip the enabled state.
                m_BehaviourComponent.enabled = !m_BehaviourComponent.enabled;

                // Wait for specified period before toggling again.
                yield return new WaitForSeconds(m_TogglePeriod);
            }
        }
    }

}

