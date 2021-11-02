using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour {
	[SerializeField] private int health;

	void SartHealth () {
		this.health = 100;
	}

	// Returns true if still alive, false if not
	bool Damage (int healthPoints) {
		this.health -= healthPoints;
		return health <= 0;
	}

	// Adds Health by points, no overheal
	public void Heal (int healthPoints) {
		if (this.health < 100) {
			this.health = Math.Min(100, this.health + healthPoints);
		}
	}

	// Adds Health by points, with overheal to 120
	public void HealOver (int healthPoints) {
		this.health = Math.Min(120, this.health + healthPoints);
	}
}