using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// General Projectile Card
public class ProjectileCard : Card {
	[SerializeField] private GameObject projectile; // projectile this card shoots
	[SerializeField] private float projVelocity; // projectile velocity
	[SerializeField] public Sprite cardSprite;

	// Shoots this projectile
	// xDirection: The direction the player is facing on the x axis
	// yDirection: The direction the player is facing on the y axis
	public override void Activate (int xDirection, int yDirection, Vector3 playerPos) {
		GameObject proj = Instantiate (this.projectile);
		proj.transform.position = playerPos;
		proj.transform.Rotate (GetOrientation (), Space.Self);

		Rigidbody2D rb = proj.GetComponent<Rigidbody2D> ();
		rb.AddForce (new Vector2 (this.projVelocity * xDirection, this.projVelocity * yDirection));

		// Local, gets orientation of rotation based on x and y direction of player
		Vector3 GetOrientation () {
			float rotateZ = 0;

			// Horizontal Direction
			if (xDirection > 0) {
				rotateZ = -90;
			} else if (xDirection < 0) {
				rotateZ = 90;
			}

			// Vertical Direction
			if (yDirection < 0) {
				rotateZ = 180;
			}
			return new Vector3 (0, 0, rotateZ);
		}
	}
}
