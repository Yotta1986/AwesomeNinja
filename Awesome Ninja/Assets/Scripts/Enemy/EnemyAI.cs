using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour {

	public Animator anim;
	public Transform targetToChase;
	public NavMeshAgent agent;
	public float stoppingDistance  = 1.0f;
	public float discoverDistance  = 5.0f;

	public Transform[] patrolPoints;
	private Transform pointApproching;
	private float distanceToPointApproching;


	private string ANIMATION_RUN = "Run";
	private string ANIMATION_SPEED = "Speed";
	private string ANIMATION_ATTACK = "Attack";

	void Start () 
	{
		// this agent.speed is useless, don't move thought NavMeshAgent, we use anim to mve
		agent.speed = 1;
		agent.stoppingDistance = stoppingDistance; 

		anim.SetBool (ANIMATION_RUN, true);
	}
	
	// Update is called once per frame
	void Update () 
	{
		float distance;
		bool canSeePlayer = true;
		// According to distance and visibility 

		distance = Vector3.Distance (transform.position, targetToChase.position);

		if (distance <= discoverDistance && canSeePlayer)
			chase ();
		else if (distance <= stoppingDistance && canSeePlayer)
			attack ();
		else
			patrol ();
		

		if (Vector3.Distance (transform.position, targetToChase.position) > stoppingDistance) 
		{
			anim.SetBool (ANIMATION_ATTACK, false);
			//anim.SetFloat (ANIMATION_SPEED, 1.0f);
			//anim.SetBool (ANIMATION_RUN, true);
		}
		else
		{
			anim.SetBool (ANIMATION_RUN, false);
			anim.SetBool (ANIMATION_ATTACK, true);
			anim.SetFloat (ANIMATION_SPEED, 0.0f);
		}
	}

	void patrol()
	{
		
	}

	void chase()
	{
		agent.SetDestination (targetToChase.position);
		anim.SetBool (ANIMATION_ATTACK, false);
		anim.SetFloat (ANIMATION_SPEED, 1.0f);
		anim.SetBool (ANIMATION_RUN, true);
	}

	void attack()
	{
		agent.SetDestination (targetToChase.position);
		anim.SetBool (ANIMATION_ATTACK, true);
		anim.SetFloat (ANIMATION_SPEED, 1.0f);
		anim.SetBool (ANIMATION_RUN, false);
	}
}
