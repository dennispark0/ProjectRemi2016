using UnityEngine;
using System.Collections;

public class WallScript : MonoBehaviour {
	public int room;
	public GameObject thing;
	int count;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		
	}

	IEnumerator testing () {


			
		count++;
		Debug.Log ("There are " + Resources.FindObjectsOfTypeAll<Transform>().Length + " objects." );
	
		yield return new WaitForSeconds (3f);
		for(int i = 0; i<100;i++)
		Instantiate (thing, transform.position+Vector3.up, Quaternion.identity);
		//StartCoroutine(testing ());
	}


}
