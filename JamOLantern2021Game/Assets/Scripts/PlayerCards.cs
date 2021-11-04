using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Holds the cards the player has in their deck
// Many fields are set on start inside FirstFloorManager class
public class PlayerCards : MonoBehaviour {

	[SerializeField] private List<Card> cards; // list of Card's in inventory, should all be prefabs
	[HideInInspector] public KeyCode keyToUse; // Key pressed to use card
	[HideInInspector] public KeyCode keyToSkip; // Key pressed to skip card

	[SerializeField] private PlayerMovement playerMovement; // Player movement of this player
	[HideInInspector] public Image currentActiveCardImage; // the active UI card seen on the canvas for this player
	[HideInInspector] public TextMeshProUGUI currentNumText; //UI Element
	[HideInInspector] public TextMeshProUGUI deckSizeText; //UI Element

	private int currentCardIndex; // the current card in the players hand

	private void Start () {
		this.currentCardIndex = 0;
		this.UpdateCardUI ();
	}

	// called every frame
	private void Update () {
		// To activate card
		if (Input.GetKeyDown (this.keyToUse)) {
			this.UseCard ();
		}

		// Skip a card
		if (Input.GetKeyDown (this.keyToSkip)) {
			this.IncCurrentIndex ();
			this.UpdateCardUI ();
		}
	}

	// Goes to next card in deck, wraps around if needed
	void IncCurrentIndex () {
		// go to next card in deck
		if (this.currentCardIndex < this.cards.Count - 1) {
			this.currentCardIndex++;
		} else {
			this.currentCardIndex = 0;
		}
	}

	// Uses current card
	void UseCard () {
		// Does the deck have cards? 
		if (this.cards.Count > 0) {
			this.cards [this.currentCardIndex].Activate ((int)this.playerMovement.playerFacing.x,
				(int)this.playerMovement.playerFacing.y, this.transform.position);
			if (this.cards [this.currentCardIndex].dispenseWhenUsed) { // if dispensed when used
				cards.RemoveAt (currentCardIndex); // remove from stack
				if (this.cards.Count == currentCardIndex) { // are we at our last card in teh deck?
					IncCurrentIndex ();
					//this.currentCardIndex--;
				}
			} else { // if not dispensed when used
				this.IncCurrentIndex (); // go to next card in deck
			}

			this.UpdateCardUI ();
		} else { // the deck has no cards
				 //TODO: Add negative noise here
		}

	}

	// updates the current card image UI
	private void UpdateCardUI () {

		// is Deck empty? 
		if (this.cards.Count <= 0) {
			this.currentActiveCardImage.sprite = null;
		} else {
			this.currentActiveCardImage.sprite = this.cards [this.currentCardIndex].sprite;
		}
		this.currentNumText.text = this.currentCardIndex + 1 + "";
		this.deckSizeText.text = "/ " + this.cards.Count;
	}

	// Adds a card to the list
	public void AddCard (Card card) {
		this.cards.Add (card);
		this.UpdateCardUI ();
	}
}