using UnityEngine;

public class ItemInteractor : MonoBehaviour
{
    public Item item; // Przypisz odpowiedni przedmiot w Unity Inspector

    public virtual void Interact()
    {
        Inventory.instance.Add(item); // Dodaj przedmiot do ekwipunku
        // Opcjonalnie: Dodaj dźwięki lub efekty wizualne interakcji
        Destroy(gameObject); // Opcjonalnie: Usuń obiekt z gry po podniesieniu przedmiotu
    }
}