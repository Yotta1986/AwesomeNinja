using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMotor : MonoBehaviour {

	public Animator anim;


	[HideInInspector]
	public Vector3 movementDirection;
	[HideInInspector]
	public bool isMoving;

	void Awake () 
	{
		
	}
	
	void Start()
	{
		movementDirection = transform.forward;
	}

	void Update()
	{
		// anime and  move forward
		if (isMoving) 
			anim.SetBool (PlayerStates.RUN, true);
		else 
			anim.SetBool (PlayerStates.RUN, false);
	}

	void FixedUpdate()
	{
		// rotate
		if (isMoving) 
		{
			float angle = signedAngle (movementDirection, transform.forward, Vector3.up);

			if( angle > -10 && angle < 10)
				transform.Rotate (0, angle , 0);
			else
				transform.Rotate (0, angle / 3 , 0);
		}
	}

	float signedAngle(Vector3 targetDir, Vector3 forward, Vector3 axis)
	{
		targetDir = targetDir - Vector3.Project (targetDir, axis);
		forward = forward - Vector3.Project (forward, axis);

		float angle = Vector3.Angle (targetDir, forward);

		return angle * 
			(Vector3.Dot (axis, Vector3.Cross(targetDir, forward)) < 0 ? 1 : -1); 		
	}

}
