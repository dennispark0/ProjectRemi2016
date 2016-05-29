using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public GameObject explosion;
	GameObject cursor;
	public int damage;
	public int penetration;
	public int type = 0;
	public float speed;
	SpriteRenderer sr;
	Animator anim;
	// Use this for initialization
	void Start () {
		cursor = GameObject.Find ("Cursor");
		sr = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator> ();
		anim.SetInteger("Type", type);
		Color tmp = sr.color;
		tmp.a = 0.98f;
		GetComponent<SpriteRenderer> ().color = tmp;
	



	}

	// Update is called once per frame
	void Update () {
		if (type == 1 && speed < 7.5)
			speed += 14 * Time.deltaTime;
		transform.Translate (Vector3.up *speed*Time.deltaTime);
	
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag != "Player" && coll.gameObject.tag != "Trigger" && coll.gameObject.tag !="Cursor"
			&& coll.gameObject.tag!="Bullet" && type!=4) {
			if (explosion != null) {
				var b = Instantiate (explosion, transform.position, Quaternion.AngleAxis(-transform.rotation.z,Vector3.back));
				var script = ((GameObject) b).GetComponent<Animator> ();
				script.SetInteger ("Type", type);
			}
			Destroy (gameObject);

		}
	}

	IEnumerator Death (){
		yield return new WaitForSeconds(2.0f);
		Destroy (gameObject);
	}
}
