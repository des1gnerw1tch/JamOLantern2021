using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// General Projectile Card
public class HealingCard : Card {
	[SerializeField] private float health; // health done to enemies
	[SerializeField] public Sprite cardSprite;

	// Heals 
	public override void Activate () {
		foreach (PlayerHealth curPlay in FindObjectsOfType<PlayerHealth>()) {
            curPlay.Heal(health);
        }
	}

    // Heals with overheal
	public override void ActivateOverheal () {
		foreach (PlayerHealth curPlay in FindObjectsOfType<PlayerHealth>()) {
            curPlay.HealOver(health)
        }
	}
}
