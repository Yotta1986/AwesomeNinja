using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMotor : MonoBehaviour {

	public Rigidbody rb;
	public Animator anim;

	public float walkingSpeed = 5f;
	public float walkingSnapyness = 50f;
	public float turningSmoothing = 0.3f;

	[HideInInspector]
	public Vector3 movementDirection;

	private Vector3 faceDirection;

	void Awake () 
	{
		rb = GetComponent<Rigidbody> ();
	}
	
	void Start()
	{
		faceDirection = transform.forward;
	}

	void Update()
	{
		// set animation
		if (movementDirection.magnitude > 0) 
			anim.SetBool (AnimStates.RUN, true);
		else 
			anim.SetBool (AnimStates.RUN, false);
	}

	void FixedUpdate()
	{
		// move
		Vector3 deltaVelocity = movementDirection * walkingSpeed - rb.velocity;
		rb.AddForce (deltaVelocity * walkingSnapyness, ForceMode.Acceleration);

		// rotate
		faceDirection = movementDirection;
		if (faceDirection == Vector3.zero)
			rb.angularVelocity = Vector3.zero;
		else {
			float rotationAngle = AnglesAroundAxis (transform.forward, faceDirection, Vector3.up);
			rb.angularVelocity = Vector3.up * rotationAngle * turningSmoothing;
		}
	}

	float AnglesAroundAxis(Vector3 dirA, Vector3 dirB, Vector3 axis)
	{
		dirA = dirA - Vector3.Project (dirA, axis);
		dirB = dirB - Vector3.Project (dirB, axis);

		float angle = Vector3.Angle (dirA, dirB);

		return angle * 
			(Vector3.Dot (axis, Vector3.Cross(dirA, dirB)) < 0 ? -1 : 1); 		// keep angle positive
	}
}
