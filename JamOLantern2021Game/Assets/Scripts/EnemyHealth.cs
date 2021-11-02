using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHealth : MonoBehaviour {
	[SerializeField] private int health;


	// Returns true if still alive, false if not
	bool Damage (int healthPoints) {
		this.health -= healthPoints;
		return health <= 0;
	}

}
