using System;
using UnityEngine;

interface IInteractable {
    public void Interact();
}

public class Interactor : MonoBehaviour {
    public Transform interactionSource;
    public float interactRange;
    void Start() {
        
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            Ray2D r = new Ray2D(interactionSource.position, interactionSource.forward);

            RaycastHit2D hitInfo = Physics2D.Raycast(r.origin, r.direction, interactRange);

            if (hitInfo.collider != null) {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj)) {
                    
                }
            }
        }
        
    }
}