using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Deals with player selection scene
public class PlayerSelectManager : MonoBehaviour {
	private Vector3 playersToActivate; // 0 denotes off, 1 denotes first player, 2 denotes second player
	private int counter;

	// Called on first frame
	private void Start () {
		this.playersToActivate = new Vector3 (0, 0, 0);
		this.counter = 1;
	}
	// When player selected button is clicked
	public void CarpenterSelected () {
		this.playersToActivate.z = counter;
		counter++;
	}

	public void CrusaderSelected () {
		this.playersToActivate.x = counter;
		counter++;
	}

	public void PriestSelected () {
		this.playersToActivate.y = counter;
		counter++;
	}

	// if player has selected all players
	private void Update () {
		if (counter > 2) {
			FirstFloorManager.playersToActivate = this.playersToActivate;
			SceneManager.LoadScene ("Controls");
		}
	}
}
