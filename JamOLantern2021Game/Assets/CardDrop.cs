using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A card drop on the ground
public class CardDrop : MonoBehaviour {
	[SerializeField] private bool Crusader;
	[SerializeField] private bool Priest;
	[SerializeField] private bool Carpenter;
	[SerializeField] private Card card;

	// on trigger enter, will check for player type before adding
	private void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag ("Player")) {
			if (this.Crusader) {
				try {
					other.gameObject.GetComponent<GunGirlClass> ().AddCard (this.card);
					Destroy (this.gameObject);
				}
				catch (System.Exception ex) { }
			} else if (this.Priest) {
				try {
					other.gameObject.GetComponent<PriestClass> ().AddCard (this.card);
					Destroy (this.gameObject);
				}
				catch (System.Exception ex) { }
			} else if (this.Carpenter) {
				try {
					other.gameObject.GetComponent<CarpenterClass> ().AddCard (this.card);
					Destroy (this.gameObject);
				}
				catch (System.Exception ex) { }
			} else {
				other.gameObject.GetComponent<PlayerCards> ().AddCard (this.card);
				Destroy (this.gameObject);
			}

		}
	}
}
