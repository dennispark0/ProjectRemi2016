using UnityEngine;
using System.Collections;

public class Serializer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (!PlayerPrefs.HasKey ("initialized")) {
		
			Debug.Log ("Started");
			PlayerPrefs.SetInt ("SaveStation", 0);
			PlayerPrefs.SetInt ("Feather_Boots", 0);
			PlayerPrefs.SetInt ("Blaster", -1);
			PlayerPrefs.SetInt ("Missile", 0);
			PlayerPrefs.SetInt ("SaveStation", 0);
			PlayerPrefs.SetInt ("SaveStation", 0);
			PlayerPrefs.SetInt ("SaveStation", 0);
			PlayerPrefs.SetInt ("initialized", 0);

		}
	}
	
	// Update is called once per frame
	void Update () {
		NewGame ();
	}

	void NewGame(){
		if (Input.GetKeyDown (KeyCode.Alpha0)) {
			Debug.Log ("Deleted");
			PlayerPrefs.DeleteAll ();
		}
	}
}
