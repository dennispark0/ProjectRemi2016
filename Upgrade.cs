using UnityEngine;
using System.Collections;

public class Upgrade : MonoBehaviour {
	bool hit = false;
	// Use this for initialization
	public int type;
	public int level;
	public string text;

	SpriteRenderer sr;
	AudioSource audio;

	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!audio.isPlaying && !sr.enabled)
			Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Player" && sr.enabled) {
			if (type == 0)
				PlayerPrefs.SetInt ("Blaster", level);
			if (type == 1)
				PlayerPrefs.SetInt ("Feather_Boots", level);
			audio.Play ();
			hit = true;
			sr.enabled = false;
		
			Time.timeScale = 0.0f;

		}
	}

	void OnGUI (){
		if (hit) {
			text = text.Replace ("@", "\n");
			if (GUI.Button (new  Rect (Screen.width / 2.0f - 150, Screen.height / 2.0f - 100, 300, 200), text)) {
				Time.timeScale = 1.0f;
				hit = false;

			}
		}
	}
}
