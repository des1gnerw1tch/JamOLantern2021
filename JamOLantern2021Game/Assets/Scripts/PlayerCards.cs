using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Holds the cards the player has in their deck
public class PlayerCards : MonoBehaviour {

	[SerializeField] private List<Card> cards; // list of Card's in inventory, should all be prefabs
	[SerializeField] private KeyCode keyToAttack;
	[SerializeField] private PlayerMovement playerMovement; // Player movement of this player
	private int currentCard; // the current card in the players hand

	// called every frame
	private void Update () {
		if (Input.GetKeyDown (this.keyToAttack)) {
			this.cards [this.currentCard].Activate ((int)this.playerMovement.playerFacing.x,
				(int)this.playerMovement.playerFacing.y, this.transform.position);
		}
	}
}
