using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSystem : MonoBehaviour {
	[SerializeField] private Wave [] waves;
	private int waveOn;
	[SerializeField] private GameObject stairs; // stairs to go to next floor
												// Start is called before the first frame update
	private TextMeshProUGUI waveCountUI;
	private GameObject floorCompletedText;

	void Start () {
		this.waveOn = 0;
		this.waveCountUI = GameObject.FindWithTag ("waveCounter").GetComponent<TextMeshProUGUI> ();
		this.floorCompletedText = GameObject.FindWithTag ("floorCompleted");
		this.floorCompletedText.SetActive (false);

		foreach (Wave wave in waves) {
			wave.gameObject.SetActive (false);
		}

		this.waves [this.waveOn].ActivateWave ();
		this.waves [this.waveOn].gameObject.SetActive (true);
		this.stairs.SetActive (false);
		UpdateWaveCountUI ();
	}


	public void ActivateNextWave () {
		this.waveOn++;
		if (waveOn >= waves.Length) {
			this.ActivateStairs ();
			return;
		} else {
			FindObjectOfType<AudioManager> ().Play ("nextWave");
		}
		this.waves [this.waveOn].gameObject.SetActive (true);
		this.waves [this.waveOn].ActivateWave ();
		UpdateWaveCountUI ();
	}

	// when wave is completed
	private void ActivateStairs () {
		// heal each player
		PlayerHealth [] players = FindObjectsOfType<PlayerHealth> ();
		foreach (PlayerHealth player in players) {
			player.Heal (100);
		}
		// Spawn stairs,
		FindObjectOfType<AudioManager> ().Play ("spawnStairs");
		this.stairs.SetActive (true);
		this.floorCompletedText.SetActive (true);
	}

	private void UpdateWaveCountUI () {
		this.waveCountUI.text = waveOn + 1 + "";
	}
}
