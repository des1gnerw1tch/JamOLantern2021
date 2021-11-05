using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour {
	[SerializeField] private Wave [] waves;
	private int waveOn;
	[SerializeField] private GameObject stairs; // stairs to go to next floor
												// Start is called before the first frame update
	void Start () {
		this.waveOn = 0;

		foreach (Wave wave in waves) {
			wave.gameObject.SetActive (false);
		}

		this.waves [this.waveOn].ActivateWave ();
		this.waves [this.waveOn].gameObject.SetActive (true);
		this.stairs.SetActive (false);
	}


	public void ActivateNextWave () {
		this.waveOn++;
		if (waveOn >= waves.Length) {
			this.ActivateStairs ();
			return;
		}
		this.waves [this.waveOn].gameObject.SetActive (true);
		this.waves [this.waveOn].ActivateWave ();
	}

	private void ActivateStairs () {
		FindObjectOfType<AudioManager> ().Play ("spawnStairs");
		this.stairs.SetActive (true);
	}
}
