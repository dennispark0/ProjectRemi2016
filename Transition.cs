using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Transition : MonoBehaviour
{

	public Texture blackout;

	public bool trans;
	public int forgottenRoom;
	public int activeRoom;
	public int previousRoom;

	public List<Transform> spawners;
	public List<Transform> tiles;
	GameObject player;
	float fade;

	// Use this for initialization
	void Start ()
	{
		fade = 0;
		player = GameObject.Find ("Alice");
		Transform[] s = Resources.FindObjectsOfTypeAll<Transform> ();

		for (int i = 0; i < s.Length; i++) {
			
			if (s [i].gameObject.tag == "Spawner")
				spawners.Add (s [i]);
			

			if (s [i].gameObject.tag == "Tiles")
				tiles.Add (s [i]);
			

		}

	
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		player.SetActive (!trans && fade < 0.5f);
	
		if (trans) {
			if (fade < 1.0)
				fade += Time.deltaTime * 1;
			else {
				fade = 1.0f;
				trans = false;
			}
		} else {
			if (fade > 0.0)
				fade -= 1 * Time.deltaTime;
			else
				fade = 0.0f;
		
		
		}
	}

	public void Enable ()
	{
		
		foreach (Transform t in spawners) 
			t.gameObject.SetActive (t.GetComponent<Spawner> ().room == activeRoom);



		foreach (Transform t in tiles) 
			t.gameObject.SetActive (t.GetComponent<WallScript> ().room == activeRoom);


	}

	void OnGUI ()
	{
		GUI.color = new Color (1.0f, 1.0f, 1.0f, fade);
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), blackout);
	}
}
