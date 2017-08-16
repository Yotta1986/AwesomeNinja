using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	public Animator anim;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if(Input.GetKeyDown(KeyCode.T))
		{
			anim.SetBool(AnimStates.ATTACK, true);
		}
		else if(Input.GetKeyUp(KeyCode.T))
		{
			anim.SetBool(AnimStates.ATTACK, false);
		}



		
	}
}
