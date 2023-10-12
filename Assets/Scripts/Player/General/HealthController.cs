using System;
using UnityEngine;

public class HealthController : MonoBehaviour {

    public int maxPlayerHealth = 100;
    private int currentPlayerHealth;
    
    private void Start() {
        currentPlayerHealth = maxPlayerHealth;
    }

    public void dealDamageToPlayer(int damageAmount) {
        currentPlayerHealth -= damageAmount;
    }

    public void healPlayer(int healAmount) {
        currentPlayerHealth += healAmount;

        currentPlayerHealth = Mathf.Min(currentPlayerHealth, maxPlayerHealth);
    }

    public void checkPlayerHealth() {
        Debug.Log("Current Health:"+ " " +currentPlayerHealth);
    }

    private void Die() {
        GetComponent<PerTileMover>().enabled = false;
        
        Debug.Log("Gracz umarł");
    }
}