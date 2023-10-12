using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

/// <summary>
///Base script for all weapon controllers
/// </summary>
public class WeaponController : MonoBehaviour {
    [Header("Weapon Stats")] 
    public GameObject prefab;
    public float damage;
    public float speed;
    public float cooldownDuartion;
    float currentCooldown;
    public int pierce;
    void Start() {
        currentCooldown = cooldownDuartion; //At the start set the current cooldown to be the cooldown duration
    }
    
    void Update() {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0f) { //Once the cooldown becomes 0, attack
            Attack();
        }
    }

    void Attack() {
        currentCooldown = cooldownDuartion;
        
    }
}
