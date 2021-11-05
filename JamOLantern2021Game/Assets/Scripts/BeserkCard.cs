using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Makes player invincible, all cards double damage
public class BeserkCard : Card {

	public override void Activate (int xDirection, int yDirection, Vector3 playerPos, GameObject player) {
		player.GetComponent<PlayerHealth> ().StartBeserk ();
		FindObjectOfType<AudioManager> ().Play ("beserk");
	}
}
