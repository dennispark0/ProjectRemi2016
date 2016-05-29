using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Controller2D))]
public class Player : MonoBehaviour
{
	public GameObject dust;
	public float maxJumpHeight = 4;
	public float minJumpHeight = 1;
	public float timeToJumpApex = .4f;
	public float maxGravity = -10;
	public float moveSpeed = 6;

	public int maxHearts = 3;
	public int hearts;

	public int canJump = 2;

	public bool iFrames = false;
	public bool running = false;
	public Vector2 wallLeap;

	public float wallSlideSpeedMax = 1;
	public float wallStickTime = .1f;
	float timeToWallUnstick;

	float gravity;
	float maxJumpVelocity;
	float minJumpVelocity;
	Vector3 velocity;
	float velocityXSmoothing;
	int wallDirLast = 0;
	Controller2D controller;
	Animator anim;
	Renderer rend;

	void Start ()
	{
		moveSpeed = 5 + PlayerPrefs.GetInt ("Feather_Boots");
		rend = GetComponent<Renderer> ();
		anim = GetComponent<Animator> ();
		controller = GetComponent<Controller2D> ();
		hearts = maxHearts;
		gravity = -(2 * maxJumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		maxJumpVelocity = Mathf.Abs (gravity) * timeToJumpApex;
		minJumpVelocity = 0;
		Mathf.Sqrt (2 * Mathf.Abs (gravity) * minJumpHeight);
		print ("Gravity: " + gravity + "  Jump Velocity: " + maxJumpVelocity);
	}

	IEnumerator OnTriggerEnter2D (Collider2D coll)
	{
	
		if (coll.gameObject.tag == "Enemy") {
			if (!iFrames) {
				if(hearts>0)
				hearts--;
				iFrames = true;
				yield return new WaitForSeconds (2.0f);
				iFrames = false;

			}
		}

	}




	void Update ()
	{
		anim.speed = moveSpeed / 6.0f;
		Color c = rend.material.color;
		if (iFrames)
			c.a = 0.5f;
		else
			c.a = 1.0f;
		rend.material.color = c;

		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		int wallDirX = (controller.collisions.left) ? -1 : 1;
		if (running && PlayerPrefs.GetInt ("Feather_Boots") == 2) {
			if (moveSpeed < 10)
				moveSpeed += 10 * Time.deltaTime;
			else
				moveSpeed = 10;
		}

		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			running = true;
		}
		if (Input.GetKeyUp (KeyCode.LeftShift)) {
			running = false;
			moveSpeed = 6;
		}
		float targetVelocityX = input.x * moveSpeed;
			
		velocity.x = targetVelocityX;
		//Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);



		bool wallSliding = false;
		if ((controller.collisions.left || controller.collisions.right) && wallDirLast != wallDirX && PlayerPrefs.GetInt("Feather_Boots")==1 && !controller.collisions.below && velocity.y < 0) {
			wallSliding = true;



			if (timeToWallUnstick > 0) {
				velocityXSmoothing = 0;
				velocity.x = 0;

				if (input.x == wallDirX) {
					timeToWallUnstick = wallStickTime;

				} else {
					timeToWallUnstick -= Time.deltaTime;
				}
			} else {
				timeToWallUnstick = wallStickTime;
			}

		}

		if (wallSliding) {
			if (velocity.y < -wallSlideSpeedMax) {
				velocity.y = wallSlideSpeedMax;
			}
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			Vector3 pos = transform.position;
		
			if (wallSliding && wallDirX != wallDirLast) {
				wallDirLast = wallDirX;
				velocity.x = -wallDirX * wallLeap.x;
				velocity.y = wallLeap.y;

			}

			if (controller.collisions.below) {

				velocity.y = maxJumpVelocity;
				canJump = 2;
				wallDirLast = 0;
			}

			if (canJump > 0 && PlayerPrefs.GetInt ("Feather_Boots") == 2) {
				velocity.y = maxJumpVelocity;
				canJump--;
			}

		}
		if (Input.GetKeyUp (KeyCode.Space)) {
	
			if (velocity.y > minJumpVelocity) {
				velocity.y = minJumpVelocity;
			
			}
		}

		if (velocity.y > maxGravity)
			velocity.y += gravity * Time.deltaTime;
		else
			velocity.y = maxGravity;
	
		controller.Move (velocity * Time.deltaTime, input);

		if (controller.collisions.above || controller.collisions.below) {
			velocity.y = 0;

		} 
		if (controller.collisions.below) {
			anim.SetBool ("isJumping", false);
		} else {
			anim.SetBool ("isJumping", true);
		}
	}





}