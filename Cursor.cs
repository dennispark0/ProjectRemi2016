using UnityEngine;
using System.Collections;

public class Cursor : MonoBehaviour {
	bool cTrigger = false;
	Vector3 mPosition;
	bool reloading = false;

	float reloadTime = 0.1f;
	public float angle;

	public GameObject bullet;
	public GameObject missile;
	GameObject player;
	public GameObject target;
	public int type = -1;
	// Use this for initialization
	Animator anim;
	void Start () {
		anim = GetComponent<Animator> ();
	
		UnityEngine.Cursor.lockState = CursorLockMode.Confined;
		player = GameObject.Find ("Alice");




	}
	
	// Update is called once per frame
	void Update () {
		mPosition = transform.position;
		angle = Mathf.Atan2 (mPosition.y-player.transform.position.y, mPosition.x-player.transform.position.x)*Mathf.Rad2Deg-90;
		Switch ();

		anim.SetBool ("Targeting", target != null);
	

		UnityEngine.Cursor.visible = cTrigger;

		switch(type){
		case 0:
			Firing ();
			break;
		case 1:
			Fire ();
			break;
		case 2:
			Ice ();
			break;
		case 4:
			Shadow ();
			break;
		//	Missile ();
		}	
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (cTrigger) {
				cTrigger = false;

			} else {
				cTrigger = true;

			}
				

		}
		mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		if (target != null)
			transform.position = target.transform.position;
		else {
			transform.position = mPosition;
			transform.position = Vector2.Lerp (transform.position, mPosition, 0.1f);
		}
	
	
	
	
	}

	public void Switch(){
		//if (Input.GetKeyDown (KeyCode.E))
			//type++;
		if (Input.GetKeyDown (KeyCode.Q) && PlayerPrefs.GetInt("Blaster")>=0)
			type++;
		if (type > PlayerPrefs.GetInt("Blaster"))
			type = 0;
	
	}

	public void Firing(){
	bool fire = Input.GetMouseButton (0);
		if (fire && !reloading) {
			var b =  Instantiate (bullet, player.transform.position, Quaternion.AngleAxis (angle, Vector3.forward));
			var script = ((GameObject) b).GetComponent<Bullet> ();
			script.type = type;
			script.speed = 15f;
			reloading = true;
			reloadTime = 0.1f;
		} else if (reloading) {
			reloadTime -= Time.deltaTime;
			if (reloadTime < 0)
				reloading = false;
		} else
			reloadTime = 0.1f;
	}

	public void Fire(){
		bool fire = Input.GetMouseButton (0);
		if (fire && !reloading) {
			for(int i = 0;i<3;i++){
				var b =  Instantiate (bullet, player.transform.position, Quaternion.AngleAxis(-15+15*i+angle, Vector3.forward));
			var script = ((GameObject) b).GetComponent<Bullet> ();
			script.type = type;
				script.speed = 2.5f;
			}
			reloading = true;
			reloadTime = 0.3f;
		} else if (reloading) {
			reloadTime -= Time.deltaTime;
			if (reloadTime < 0)
				reloading = false;
		} else
			reloadTime = 0.3f;
	}
	public void Ice(){
		bool fire = Input.GetMouseButton (0);
		if (fire && !reloading) {
			for(int i = 0;i<3;i++){
				var b =  Instantiate (bullet, player.transform.position, Quaternion.AngleAxis(-5+5*i+angle, Vector3.forward));
				var script = ((GameObject) b).GetComponent<Bullet> ();
				script.type = type;
				script.speed = 10f;
			}
			reloading = true;
			reloadTime = 0.5f;
		} else if (reloading) {
			reloadTime -= Time.deltaTime;
			if (reloadTime < 0)
				reloading = false;
		} else
			reloadTime = 0.5f;
	}








	public void Shadow(){
		bool fire = Input.GetMouseButton (0);
		if (fire && !reloading) {
			var b =  Instantiate (bullet, player.transform.position, Quaternion.AngleAxis (angle, Vector3.forward));
			var script = ((GameObject) b).GetComponent<Bullet> ();
			script.type = type;
			script.speed = 12f;
			reloading = true;
			reloadTime = 0.2f;
		} else if (reloading) {
			reloadTime -= Time.deltaTime;
			if (reloadTime < 0)
				reloading = false;
		} else
			reloadTime = 0.2f;
	}







	public void Missile(){
		if (Input.GetMouseButtonDown(0)) {
			Instantiate (missile, player.transform.position, Quaternion.identity);
		}
	}

	void LockOn(GameObject obj){
		if (Input.GetMouseButtonDown (1))
			target = obj;
		if (Input.GetMouseButtonUp (1))
			target = null;
	}

	void OnTriggerStay2D(Collider2D coll){

		if (coll.gameObject.tag == "Enemy") {
			Debug.Log ("Stuff");
			LockOn (coll.gameObject);
		}
	}






}
