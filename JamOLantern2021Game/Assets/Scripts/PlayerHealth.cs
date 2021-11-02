using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
	[SerializeField] private int health;

	void SartHealth () {
		this.health = 100;
	}

	// Returns true if still alive, false if not
	boolean Damage (int healthPoints) {
		this.health -= healthPoints;
		return health <= 0;
	}

	// Adds Health by points, no overheal
	void Health (int healthPoints) {
		if (health < 100) {
			this.health = Math.Min(100, this.health + healthPoints);
		}
	}

	// Adds Health by points, with overheal to 120
	void HealthOverheal (int healthPoints) {
		this.health = Math.Min(120, this.health + healthPoints);
	}
}
