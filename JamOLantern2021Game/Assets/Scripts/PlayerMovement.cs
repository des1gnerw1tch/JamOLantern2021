using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	[SerializeField] private Rigidbody2D body;
	[HideInInspector] public KeyCode left;
	[HideInInspector] public KeyCode right;
	[HideInInspector] public KeyCode up;
	[HideInInspector] public KeyCode down;
	[SerializeField] private Animator animator; // animator for this character

	//[SerializeField] private float horizontalMovement;
	//[SerializeField] private float verticalMovement;
	[SerializeField] private float sprintSpeed = 10.0f;
	[SerializeField] private float speedDampener = 0.7f;

	// x: The direction the player is facing on the x axis
	// y: The direction the player is facing on the y axis
	public Vector2 playerFacing; // what direction is the player facing?

	// Start is called before the first frame update
	void Start () {
		body = GetComponent<Rigidbody2D> ();
		this.playerFacing = new Vector2 (0, -1); // starts facing forward
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (left) && Input.GetKey (up)) {
			body.velocity = new Vector2 (-sprintSpeed
				+ speedDampener, sprintSpeed + speedDampener);
		} else if (Input.GetKey (left) && Input.GetKey (down)) {
			body.velocity = new Vector2 (-sprintSpeed
				+ speedDampener, -sprintSpeed + speedDampener);
		} else if (Input.GetKey (right) && Input.GetKey (up)) {
			this.animator.SetInteger ("xVelocity", 0);
			body.velocity = new Vector2 (sprintSpeed
				+ speedDampener, sprintSpeed + speedDampener);
		} else if (Input.GetKey (right) && Input.GetKey (down)) {
			this.animator.SetInteger ("xVelocity", 0);
			body.velocity = new Vector2 (sprintSpeed
				+ speedDampener, -sprintSpeed + speedDampener);
		} else if (Input.GetKey (left)) {
			body.velocity = new Vector2 (-sprintSpeed, body.velocity.y);
			this.playerFacing = new Vector2 (-1, 0);
			this.animator.SetInteger ("xVelocity", -1);
		} else if (Input.GetKey (right)) {
			body.velocity = new Vector2 (sprintSpeed, body.velocity.y);
			this.playerFacing = new Vector2 (1, 0);
			this.animator.SetInteger ("xVelocity", 1);
		} else if (Input.GetKey (up)) {
			body.velocity = new Vector2 (body.velocity.x, sprintSpeed);
			this.playerFacing = new Vector2 (0, 1);
			this.animator.SetInteger ("yVelocity", 1);
		} else if (Input.GetKey (down)) {
			body.velocity = new Vector2 (body.velocity.x, -sprintSpeed);
			this.playerFacing = new Vector2 (0, -1);
			this.animator.SetInteger ("yVelocity", -1);
		} else {
			body.velocity = new Vector2 (0, 0);
			this.animator.SetTrigger ("stoppedWalking");
			this.animator.SetInteger ("xVelocity", 0);
			this.animator.SetInteger ("yVelocity", 0);
		}
		if (this.animator.GetInteger ("xVelocity") != 0 && this.animator.GetInteger ("yVelocity") != 0) {
			this.animator.SetInteger ("xVelocity", 0);
		}
	}
}