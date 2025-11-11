using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ToggeMotor : MonoBehaviour
{
    [SerializeField] SliderJoint2D m_Joint;

    [SerializeField] float m_TogglePeriod = 1f;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);

        if (m_Joint)
        {
            while (true)
            {
                // Flip the enabled state.
                m_Joint.useMotor = !m_Joint.useMotor;

                // Wait for specified period before toggling again.
                yield return new WaitForSeconds(m_TogglePeriod);
            }
        }
    }
}
