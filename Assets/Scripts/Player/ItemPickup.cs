using UnityEngine;

public class ItemPickup : MonoBehaviour, IInteractable {

    public Item item;

    public void Interact() {
        PickUp();
        
    }

    void PickUp() {
        Debug.Log("Picking Up " + item.name);
        // Add Item to inventory
        
        Destroy(gameObject);
    }
}