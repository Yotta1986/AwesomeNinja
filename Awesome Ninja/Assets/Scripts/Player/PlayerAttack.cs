using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	public Animator anim;

	void Update () 
	{
		
		if(Input.GetKeyDown(KeyCode.T))
		{
			anim.SetBool(PlayerStates.ATTACK, true);
		}
		else if(Input.GetKeyUp(KeyCode.T))
		{
			anim.SetBool(PlayerStates.ATTACK, false);
		}	
	}
}
