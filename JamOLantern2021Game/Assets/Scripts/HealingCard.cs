using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// General Projectile Card
public class HealingCard : Card {
	[SerializeField] private int health; // health done to enemies
	[SerializeField] public bool overheal; //if has overheal

	// Heals 
	public override void Activate (int xDirection, int yDirection, Vector3 playerPos) {
		foreach (PlayerHealth curPlay in FindObjectsOfType<PlayerHealth> ()) {
			if (this.overheal) {
				curPlay.HealOver (this.health);
			} else {
				curPlay.Heal (this.health);
			}
		}
		FindObjectOfType<AudioManager> ().Play ("Heal");
	}
}
