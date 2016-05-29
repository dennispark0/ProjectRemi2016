using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public GameObject control;
	Transition t;
	public Transform Player;
	public Vector2
	Margin,
	Smoothing;

	public BoxCollider2D B;
	public bool IsFollowing { get; set;}
	public Vector3
	_min,
	_max;

	// Use this for initialization
	void Start () {
		control = GameObject.Find ("Control");
		t = control.GetComponent<Transition> ();
		_min = B.bounds.min;
		_max = B.bounds.max;

		IsFollowing = true;

	}
	
	// Update is called once per frame
	void Update () {
		var x = transform.position.x;
		var y = transform.position.y;
		if (IsFollowing) {
			if (Mathf.Abs (x - Player.position.x) > Margin.x)
				x = Mathf.Lerp (x,Player.position.x, Smoothing.x * Time.deltaTime);
			if (Mathf.Abs (y - Player.position.y) > Margin.y)
				y = Mathf.Lerp (y, Player.position.y, Smoothing.y * Time.deltaTime);

		}
		var cameraHalfWidth = GetComponent<Camera>().orthographicSize * ((float)Screen.width / Screen.height);
		var c = GetComponent<Camera> ().orthographicSize;
		x = Mathf.Clamp (x, _min.x + cameraHalfWidth, _max.x - cameraHalfWidth);
		y = Mathf.Clamp (y, _min.y + c, _max.y - c);
		if(!t.trans)
		transform.position = new Vector3 (x, y, transform.position.z);
	}
}
