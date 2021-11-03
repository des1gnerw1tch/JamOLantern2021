using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	[SerializeField] private Animator animator; // this enemies animator
	private Transform playerToFollow;
	public float moveSpeed = 4f;
	public float range = 2f;
	private Rigidbody2D body;
	private Vector2 movement;
	GameObject [] possibleTargets;


	// Start is called before the first frame update
	void Start () {
		body = this.GetComponent<Rigidbody2D> ();
		this.possibleTargets = GameObject.FindGameObjectsWithTag ("Player");
	}

	// Update is called once per frame
	void Update () {
		float minDistance = float.MaxValue;
		foreach (GameObject target in possibleTargets) {
			if (Vector3.Distance (transform.position, target.transform.position) <= minDistance) {
				minDistance = Vector3.Distance (transform.position, target.transform.position);
				playerToFollow = target.transform;
			}
		}
		Vector3 direction = playerToFollow.position - transform.position;
		direction.Normalize ();
		movement = direction;
	}

	private void FixedUpdate () {
		moveCharacter (movement);
	}
	void moveCharacter (Vector2 direction) {
		body.MovePosition ((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
		if (Mathf.Abs (direction.x) > Mathf.Abs (direction.y)) { // more horizontal movement than vertical
			this.animator.SetInteger ("xVelocity", floatToInt (direction.x));
			this.animator.SetInteger ("yVelocity", 0);
		} else {
			this.animator.SetInteger ("xVelocity", 0);
			this.animator.SetInteger ("yVelocity", floatToInt (direction.y));
		}
		Debug.Log (direction.x);
		//Debug.Log (direction.y);

		int floatToInt (float number) {
			if (number < 0) {
				return -1;
			} else {
				return 1;
			}

		}
	}
}