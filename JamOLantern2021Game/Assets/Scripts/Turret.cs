using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
	[SerializeField] private GameObject projectile; // projectile this card shoots
	[SerializeField] private float projVelocity; // projectile velocity
	[SerializeField] private float timeBetweenBullets;
	[SerializeField] private float lifetime; // in seconds
	private bool isShooting;

	// shoots the turret
	private void Start () {
		this.isShooting = true;
		StartCoroutine ("Shooting");
		StartCoroutine ("EndShooting");
	}
	void Shoot () {
		GameObject proj = Instantiate (this.projectile);
		proj.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y,
			this.transform.position.z);
		Rigidbody2D rb = proj.GetComponent<Rigidbody2D> ();
		Vector3 dir = this.transform.right * -1;
		rb.AddForce (this.projVelocity * dir);
	}

	IEnumerator Shooting () {
		AudioManager am = FindObjectOfType<AudioManager> ();
		while (this.isShooting) {
			yield return new WaitForSeconds (this.timeBetweenBullets);
			am.Play ("turret");
			Shoot ();
		}
	}

	IEnumerator EndShooting () {
		yield return new WaitForSeconds (this.lifetime);
		this.isShooting = false;
		Destroy (this.gameObject);
	}
}
