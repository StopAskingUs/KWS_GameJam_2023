using UnityEngine;

public class ItemPickup : MonoBehaviour, IInteractable {

    public Item item;

    public void Interact() {
        PickUp();
        
    }

    void PickUp() {
        Debug.Log("Picking Up " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);
        if (wasPickedUp)
            Destroy(gameObject);
    }
}