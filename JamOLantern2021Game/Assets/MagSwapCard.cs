using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player will gain X random general cards
public class MagSwapCard : Card {
	[SerializeField] private Card [] cardPool;
	[SerializeField] private int cardsToGain;

	// When card is activated
	public override void Activate (int xDirection, int yDirection, Vector3 playerPos, GameObject player) {
		PlayerCards playerDeck = player.GetComponent<PlayerCards> ();
		for (int i = 0; i < cardsToGain; i++) {
			int rand = Random.Range (0, cardPool.Length);
			playerDeck.AddCard (this.cardPool [rand]);
		}
	}

}
