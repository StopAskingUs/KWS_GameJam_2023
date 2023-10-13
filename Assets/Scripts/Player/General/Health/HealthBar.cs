using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    public GameObject heartPrefab;
    public HealthController playerHealth;
    private List<HealthHeart> hearts = new List<HealthHeart>();

    
    
    public void ClearHearts() {

        foreach (Transform t in transform) {
            Destroy(t.gameObject);
        }
        hearts = new List<HealthHeart>();
        
    }
}
