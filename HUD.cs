using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	GameObject player;
	GameObject cursor;
	Player p;
	Cursor c;

	public Texture heartTexture;
	public Texture heartContainer;
	public Texture manaBar;
	public Texture mana;
	public Texture frame;

	public Texture fire;
	public Texture leaf;
	public Texture ice;
	public Texture light;
	public Texture dark;
	Texture element;
	int t;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Alice");
		cursor = GameObject.Find ("Cursor");
		p = player.GetComponent<Player> ();
		c = cursor.GetComponent<Cursor> ();

	}
	


	void OnGUI (){
		Elemental ();
		int h = p.hearts;
		int m = p.maxHearts;
		for(int j = 0; j<m;j++)
		GUI.DrawTexture (new Rect (13+20*j, 10, 20, 20), heartContainer, ScaleMode.StretchToFill);
		for(int i= 0; i<h; i++)
		GUI.DrawTexture (new Rect (13+20*i, 10, 20, 20), heartTexture, ScaleMode.StretchToFill);
		GUI.DrawTexture (new Rect (0, 30, 100, 20), manaBar, ScaleMode.StretchToFill);
		GUI.DrawTexture (new Rect (13, 33, 72, 12), mana, ScaleMode.StretchToFill);
		GUI.DrawTexture (new Rect (13, 580, 50, 50), frame, ScaleMode.StretchToFill);
		if(element!=null)
		GUI.DrawTexture (new Rect (18, 585, 40, 40), element, ScaleMode.StretchToFill);
	}

	void Elemental(){
		
		switch (c.type) {
		case 0:
			element = leaf;
			;
			break;
		case 1:
			element = fire;
			;
			break;
		case 2:
			element = ice;
			;
			break;
		case 3:
			element = light;
			;
			break;
		case 4:
			element = dark;
			;
			break;
		}
	}
}
