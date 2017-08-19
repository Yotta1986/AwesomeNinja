using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementKeyboard : MonoBehaviour {

	public MovementMotor motor;

	private string horizontalString = "Horizontal";
	private string verticalString = "Vertical";

	private Quaternion screenMovementSpace;
	private Vector3 screenMovementForward;
	private Vector3 screenMovementRight;

	void Awake () 
	{

	}

	void Start () 
	{
		screenMovementSpace = Quaternion.Euler (0, Camera.main.transform.eulerAngles.y, 0);
		screenMovementForward = screenMovementSpace * Vector3.forward;
		screenMovementRight = screenMovementSpace * Vector3.right;
	}

	void Update () 
	{
		motor.movementDirection  = 
			Input.GetAxis (horizontalString) * screenMovementRight + Input.GetAxis (verticalString) * screenMovementForward;
		motor.movementDirection.Normalize ();

		if (Input.GetAxis (verticalString) != 0 || Input.GetAxis (horizontalString) != 0) 
			motor.isMoving = true;
		else 
			motor.isMoving = false;
		
	}
}
