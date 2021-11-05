using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	[SerializeField] private Animator animator; // this enemies animator
	private Transform playerToFollow;
	public float moveSpeed = 4f;
	//public float range = 2f;
	private Rigidbody2D body;
	private Vector2 movement;
	GameObject [] possibleTargets;
	[SerializeField] private int damageOnCollide; // how much damage this enemy will do to player on collide
	[SerializeField] private GameObject [] cardsCanDrop;
	[SerializeField] private int numCardsToDrop;
	private int currentDropNum;


	// Start is called before the first frame update
	void Start () {
		body = this.GetComponent<Rigidbody2D> ();
		this.possibleTargets = GameObject.FindGameObjectsWithTag ("Player");
		this.currentDropNum = 0;
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

		int floatToInt (float number) {
			if (number < 0) {
				return -1;
			} else {
				return 1;
			}

		}
	}

	// if bumped into something
	private void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.CompareTag ("Player")) { // if is a player
			FindObjectOfType<AudioManager> ().Play ("damage");
			if (other.gameObject.GetComponent<PlayerHealth> ().Damage (this.damageOnCollide)) {
				Debug.Log ("Player died game freezed");
				Time.timeScale = 0f;
			}
		}
	}

	// This will drop a random valid card for archetypes chosen
	public void DropCard () {
		Vector2 dropWiggle = new Vector2 (Random.Range (0.1f, 0.5f), Random.Range (0.1f, 0.5f));
		Vector3 toSpawn = new Vector3 (this.transform.position.x + dropWiggle.x, this.transform.position.y +
			dropWiggle.y, this.transform.position.z);
		int num = Random.Range (0, this.cardsCanDrop.Length);
		if (this.cardsCanDrop [num].GetComponent<CardDrop> ().Priest) {
			if (FirstFloorManager.playersToActivate.y > 0) { // if priest is in game
				Instantiate (this.cardsCanDrop [num], toSpawn, Quaternion.identity);
			} else {
				this.DropCard ();
			}
		} else if (this.cardsCanDrop [num].GetComponent<CardDrop> ().Crusader) {
			if (FirstFloorManager.playersToActivate.x > 0) { // if gungirl is in game
				Instantiate (this.cardsCanDrop [num], toSpawn, Quaternion.identity);
			} else {
				this.DropCard ();
			}
		} else if (this.cardsCanDrop [num].GetComponent<CardDrop> ().Carpenter) {
			if (FirstFloorManager.playersToActivate.z > 0) { // if carpenter is in game
				Instantiate (this.cardsCanDrop [num], toSpawn, Quaternion.identity);
			} else {
				this.DropCard ();
			}
		} else { // general card
			Instantiate (this.cardsCanDrop [num], toSpawn, Quaternion.identity);
		}

		this.currentDropNum++;
		if (this.currentDropNum < this.numCardsToDrop) {
			this.DropCard ();
		}
	}
}