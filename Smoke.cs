using UnityEngine;
using System.Collections;

public class Smoke : MonoBehaviour {
	Animator a;
	Animation anim;
	// Use this for initialization
	IEnumerator Start () {
		a = GetComponent<Animator> ();
		anim = a.GetComponent<Animation> ();
		//a.speed = 2.0f;
		do {
			yield return null;
		} while (AnimatorIsPlaying ());
			Destroy (gameObject);

	}
	
	// Update is called once per frame
	void Update () {

	}

	bool AnimatorIsPlaying(){
		return a.GetCurrentAnimatorStateInfo (0).length > a.GetCurrentAnimatorStateInfo (0).normalizedTime;
	}
}
