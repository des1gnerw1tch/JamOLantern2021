using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A single Wave, includes multiple spawners
public class Wave : MonoBehaviour {
	[SerializeField] private Spawner [] spawners;
	private int numSpawnersDone; // how many spawners are finished spawning

	private void Awake () {
		this.numSpawnersDone = 0;
	}

	public void ActivateWave () {
		foreach (Spawner spawner in spawners) {
			spawner.gameObject.SetActive (true);
			spawner.wave = this;
		}
	}

	public void IncSpawnersDone () {
		this.numSpawnersDone++;
		if (this.numSpawnersDone >= spawners.Length) {
			FindObjectOfType<WaveSystem> ().ActivateNextWave ();
		}
	}
}
