using UnityEngine;

public class RotateObject : MonoBehaviour
{
    // Rotation speed (adjustable from the inspector)
    public float rotationSpeed = 50f;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Check for Q and E key inputs
        if (Input.GetKey(KeyCode.Q))
        {
            // Rotate the object upward
            rb.angularVelocity = rotationSpeed;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            // Rotate the object downward
            rb.angularVelocity = -rotationSpeed;
        }
        else //Stop the rotation
        {
            rb.angularVelocity = 0;
        }

    }

}

