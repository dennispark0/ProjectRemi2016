using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public int room;
	public GameObject[] obj;
	public Vector2[] origin;
	// Use this for initialization
	void OnEnable () {
		Spawn ();
	}
	
	// Update is called once per frame
	void Spawn (){
		for (int i = 0; i < obj.Length; i++) {
			Instantiate (obj [i], new Vector3(origin[i].x,origin[i].y,0), Quaternion.identity);
		}

	}




}
