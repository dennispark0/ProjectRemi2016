using UnityEngine;
using System.Collections;

public class Crawler : MonoBehaviour {
	 public float hSpeed;
	public float speed;
	public int health;
	public int wallDirX = 0;
	GroundEnemy groundAI;
	Controller2D controller;
	// Use this for initialization
	void Start () {
		StartCoroutine (Crawl ());
		groundAI = GetComponent<GroundEnemy> ();
		controller = GetComponent<Controller2D> ();
	}

	// Update is called once per frame
	void Update () {
		wallDirX = (controller.collisions.left) ? -1 : 1;
		groundAI.velocity.x = hSpeed;
		if(hSpeed!=0)
		transform.localScale = new Vector3(-Mathf.Sign (hSpeed),1,1);

	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Bullet") {
			Bullet b = coll.gameObject.GetComponent<Bullet> ();
			int d = b.damage;
			health -= d;
		}
		if (health < 0)
			Destroy (gameObject);
		if (coll.gameObject.tag == "Trigger") {

			hSpeed = -wallDirX*speed;
	
		}
	}
		

	IEnumerator Crawl (){
		int outcome = Random.Range (0, 3);

			if (outcome == 0)
				hSpeed = 0;
			else if (outcome == 1)
				hSpeed = speed;
			else
				hSpeed = -speed;
		
		yield return new WaitForSeconds (0.6f);
		StartCoroutine (Crawl ());


	}
}
