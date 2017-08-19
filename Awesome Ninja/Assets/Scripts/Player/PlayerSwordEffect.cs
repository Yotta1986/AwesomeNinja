using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerSwordEffect : MonoBehaviour {
	
	public MeleeWeaponTrail meleeWeaponTrail;
	public Transform sword;

	public GameObject hitPoint;

	public ParticleSystem slash3GroundImpactParticleSystem;

	public AudioSource audioSource;
	public AudioClip swordSlashSound;
	public AudioClip slash3GroundImpact;
	public AudioClip slash3Yell;

	void Start () {
	}

	void Update () {
		
	}

	void SlashOneWeaponTrail(bool show) 
	{
		meleeWeaponTrail.Emit = show;
		hitPoint.SetActive (show);
		if (show) 
			audioSource.PlayOneShot (swordSlashSound);
	}

	void SlashTwoWeaponTrail(bool show) 
	{
		meleeWeaponTrail.Emit = show;
		hitPoint.SetActive (show);
		if (show) 
			audioSource.PlayOneShot (swordSlashSound);
	}

	void SlashThreeWeaponTrail(bool show) 
	{
		meleeWeaponTrail.Emit = show;
		hitPoint.SetActive (show);
		if (show) 
		{
			audioSource.PlayOneShot (slash3Yell);
		}
	}

	void SlashThreeImpact(bool show) 
	{
		if (show) 
		{
			audioSource.PlayOneShot (swordSlashSound);
			audioSource.PlayOneShot (slash3GroundImpact);
			slash3GroundImpactParticleSystem.Play ();
		}
	}
}
