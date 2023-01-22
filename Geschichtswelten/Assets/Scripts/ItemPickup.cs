using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemPickup : MonoBehaviour, IPointerDownHandler
{
    public Item Item;

    void Pickup() {
        Debug.Log("TEST");
        InventoryManager.Instance.Add(Item);
        Destroy(gameObject);
    }

    public void OnPointerDown(PointerEventData itemPick) {
      Pickup();
    }

}
