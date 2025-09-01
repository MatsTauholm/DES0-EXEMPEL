using System.Collections;
using UnityEngine;

public class HingeMotorToggle : MonoBehaviour
{
    [SerializeField] HingeJoint2D hinge;
    [SerializeField] float motorOnTime = 2f; // How long motor stays on
    [SerializeField] float motorOffTime = 2f;// How long motor stays off

    private JointMotor2D motor;

    void Start()
    {
        hinge = GetComponent<HingeJoint2D>();
        motor = hinge.motor;
        StartCoroutine(ToggleMotor());
    }
    
    IEnumerator ToggleMotor()
    {
        while (true)
        {
            // Turn ON motor
            hinge.useMotor = true;
            hinge.motor = motor;
            yield return new WaitForSeconds(motorOnTime);

            // Turn OFF motor
            hinge.useMotor = false;
            yield return new WaitForSeconds(motorOffTime);
        }
    }
}
