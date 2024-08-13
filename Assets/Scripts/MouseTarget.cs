using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Set the TargetJoint2D to follow the mouse position.
/// </summary>
public class MouseTarget : MonoBehaviour
{
	[SerializeField] bool ClickToMove = false;
	TargetJoint2D targetJoint;

	void Start()
	{
		// Fetch the target joint.
		targetJoint = GetComponent<TargetJoint2D> ();

		// Finish if no joint detected.
		if (targetJoint == null)
			return;
	} 

	public void MoveToMousePosition()
    {
            // Finish if no joint detected.
            if (targetJoint == null)
                return;

            // Calculate the world position for the mouse.
            var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Set the joint target.
            targetJoint.target = worldPos;

    }

	void FixedUpdate ()
	{
        if (ClickToMove == false)
        {
            // Finish if no joint detected.
            if (targetJoint == null)
                return;

            // Calculate the world position for the mouse.
            var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Set the joint target.
            targetJoint.target = worldPos;
        }
	}
}
