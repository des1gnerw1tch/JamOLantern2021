using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// assigns inputs to each individual player as directed from start scene
public class FirstFloorManager : MonoBehaviour {
	[Header ("Player 1 Controls/UI")]
	[SerializeField] private KeyCode move_left;
	[SerializeField] private KeyCode move_right;
	[SerializeField] private KeyCode move_up;
	[SerializeField] private KeyCode move_down;

	[SerializeField] private KeyCode keyToUse; // Key pressed to use card
	[SerializeField] private KeyCode keyToSkip; // Key pressed to skip card

	[SerializeField] private Image currentActiveCardImage; // the active UI card seen on the canvas for this player
	[SerializeField] private TextMeshProUGUI currentNumText; //UI Element
	[SerializeField] private TextMeshProUGUI deckSizeText; //UI Element

	[Header ("Player 2 Controls/UI")]
	[SerializeField] private KeyCode move_left2;
	[SerializeField] private KeyCode move_right2;
	[SerializeField] private KeyCode move_up2;
	[SerializeField] private KeyCode move_down2;

	[SerializeField] private KeyCode keyToUse2; // Key pressed to use card
	[SerializeField] private KeyCode keyToSkip2; // Key pressed to skip card


	[SerializeField] private Image currentActiveCardImage2; // the active UI card seen on the canvas for this player
	[SerializeField] private TextMeshProUGUI currentNumText2; //UI Element
	[SerializeField] private TextMeshProUGUI deckSizeText2; //UI Element

	[SerializeField] private GameObject [] players; // Players from scene

	// Vector field set to 1 if Player 1, and set to 2 if Player 2, and set to 0 if not Playing
	// x: GunGirlActivated?
	// y: PriestActivated?
	// z: CarpenterActivated?
	[SerializeField] private static Vector3 playersToActivate; // The players to activate

	// called before first frame update
	private void Awake () {
		// disable all players in beginning of game
		foreach (GameObject player in players) {
			player.SetActive (false);
		}

		playersToActivate = new Vector3 (2, 1, 0);
		// Set up Players in the scene with correct input
		this.InitiatePlayer (this.players [0], playersToActivate.x);
		this.InitiatePlayer (this.players [1], playersToActivate.y);
		this.InitiatePlayer (this.players [2], playersToActivate.z);
	}

	// Initiates a player to correct input system and activates/deactivates object if needed
	private void InitiatePlayer (GameObject playerObject, float id) {
		PlayerMovement movement = playerObject.GetComponent<PlayerMovement> ();
		PlayerCards cards = playerObject.GetComponent<PlayerCards> ();
		switch (id) {
			case 0:
				playerObject.SetActive (false);
				break;
			case 1:
				movement.left = this.move_left;
				movement.right = this.move_right;
				movement.up = this.move_up;
				movement.down = this.move_down;
				cards.keyToUse = this.keyToUse;
				cards.keyToSkip = this.keyToSkip;
				cards.currentActiveCardImage = this.currentActiveCardImage;
				cards.currentNumText = this.currentNumText;
				cards.deckSizeText = this.deckSizeText;
				playerObject.SetActive (true);
				break;
			case 2:
				movement.left = this.move_left2;
				movement.right = this.move_right2;
				movement.up = this.move_up2;
				movement.down = this.move_down2;
				cards.keyToUse = this.keyToUse2;
				cards.keyToSkip = this.keyToSkip2;
				cards.currentActiveCardImage = this.currentActiveCardImage2;
				cards.currentNumText = this.currentNumText2;
				cards.deckSizeText = this.deckSizeText2;
				playerObject.SetActive (true);
				break;
		}
	}
}
