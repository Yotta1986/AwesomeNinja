using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerSkills : MonoBehaviour {

	public Animator anim;
	private AudioSource audioSourceSkillSound;
	public AudioClip yellSound;

	public GameObject skillOneEffectType;
	public AudioClip skillOneSound;
	public Transform[] skillOneEffectTransform;
	public float skillCoolTime = 3.0f;
	private bool skillCoolFinished = true;

	private List<ParticleSystem> skillOneEffects = new List<ParticleSystem>();

	void Awake() 
	{
		for(int i = 0; i < skillOneEffectTransform.Length; i++)
		{
			var temp = Instantiate (skillOneEffectType, skillOneEffectTransform [i]);
			skillOneEffects.Add(temp.GetComponentInChildren<ParticleSystem> ());
		}

		audioSourceSkillSound = GetComponent<AudioSource> ();
	}

	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Y))
			StartCoroutine(skillOnePlay ());
	}
		
	IEnumerator skillOnePlay() 
	{ 
		if (skillCoolFinished) 
		{
			skillCoolFinished = false;
			anim.SetBool (PlayerStates.SKILL_1, true);
			audioSourceSkillSound.PlayOneShot (yellSound);
			yield return new WaitForSeconds (0.5f);
			foreach (ParticleSystem skillEffect in skillOneEffects)
				skillEffect.Play ();
			audioSourceSkillSound.PlayOneShot (skillOneSound);
			StartCoroutine(skillOneCool ());
		}
	}

	IEnumerator skillOneCool()
	{
		yield return null;
		anim.SetBool(PlayerStates.SKILL_1, false);
		yield return new WaitForSeconds (skillCoolTime);
		skillCoolFinished = true;
	}

}
