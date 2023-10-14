using System;
using UnityEngine;

public class HealthController : MonoBehaviour {

    public int maxPlayerHealth = 100;
    private int currentPlayerHealth;
    
    private void Start() {
        currentPlayerHealth = maxPlayerHealth;
    }

    public void TakeDamage (int damageAmount) {
        currentPlayerHealth -= damageAmount;

        if (currentPlayerHealth <= 0) {
            //We're dead
            //Play Death Animation
            //Show GameOverScreen
        }
    }

    public void healPlayer(int healAmount) {
        currentPlayerHealth += healAmount;

        currentPlayerHealth = Mathf.Min(currentPlayerHealth, maxPlayerHealth);
    }
    
}