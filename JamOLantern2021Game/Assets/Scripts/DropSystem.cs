using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSystem : MonoBehaviour {
	public CardDrop [] generalCards;
	public CardDrop [] priestCards;
	public CardDrop [] crusaderCards;
	public CardDrop [] carpenterCards;

	public int [] weights =
	{
        // higher weight = more likely to drop
        // corresponds to index of cards in each array.
        // the higher the index = the rarer the card
        60,
		40,
		20,
		10,
		5
	};

	public int total;
	public int random;

	// Start is called before the first frame update
	void Start () {

		for (int i = 0; i < weights.Length; i++) {
			total += weights [i];
		}

		random = Random.Range (0, total);

		// if priest made kill: call DropCards on priestCards
		// if crusader made kill: call DropCards on crusaderCards
		// if carpenter made kill: call DropCards on carpenterCards
	}

	/*public CardDrop DropCards (int random, CardDrop [] cards) {
		// unsure what the generic class is 
		if (cards.GetType () != Generic) {
			for (int i = 0; i < weights.Length; i++) {
				if (random <= weights [i]) {
					return cards [i];
				} else {
					random -= weights [i];
				}
			}
		}

		// base case: return most common generic card ?
		else {
			for (int j = 1; j < weights.Length; j++) {
				if (random <= weights [j]) {
					return cards [j];
				} else {
					random -= weights [j];
				}
			}
		}
		return generalCards [0];
}*/
}