using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Controller2D))]
public class GroundEnemy : MonoBehaviour {



	public float maxGravity = -10;



	float gravity;

	public Vector3 velocity;


	Controller2D controller;

	void Start() {

		controller = GetComponent<Controller2D> ();

		gravity = -10;

	
	
	}

	void Update() {

		//Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);



	
	


		if (velocity.y > maxGravity)
			velocity.y += gravity * Time.deltaTime;
		else
			velocity.y = maxGravity;

		controller.Move (velocity * Time.deltaTime, Vector2.zero);

		if (controller.collisions.above || controller.collisions.below) {
			velocity.y = 0;

		} 
	
	}

}