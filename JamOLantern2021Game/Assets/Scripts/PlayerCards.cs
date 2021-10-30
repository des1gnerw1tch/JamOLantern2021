using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Holds the cards the player has in their deck
public class PlayerCards : MonoBehaviour {

	[SerializeField] private List<Card> cards; // list of Card's in inventory, should all be prefabs
	[SerializeField] private KeyCode keyToAttack;
	[SerializeField] private PlayerMovement playerMovement; // Player movement of this player
	[SerializeField] private Image currentActiveCardImage; // the active UI card seen on the canvas for this player
	private int currentCardIndex; // the current card in the players hand

	private void Start () {
		this.currentCardIndex = 0;
		this.UpdateCurrentCardImage ();
	}

	// updates the current card image UI
	private void UpdateCurrentCardImage () {
		this.currentActiveCardImage.sprite = this.cards [this.currentCardIndex].sprite;
	}

	// called every frame
	private void Update () {
		// To activate card
		if (Input.GetKeyDown (this.keyToAttack)) {
			this.cards [this.currentCardIndex].Activate ((int)this.playerMovement.playerFacing.x,
				(int)this.playerMovement.playerFacing.y, this.transform.position);

			// go to next card in deck
			if (this.currentCardIndex < this.cards.Count - 1) {
				this.currentCardIndex++;
			} else {
				this.currentCardIndex = 0;
			}

			this.UpdateCurrentCardImage ();

		}
	}
}