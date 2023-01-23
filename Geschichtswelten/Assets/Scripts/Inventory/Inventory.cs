using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] public GameObject[] itemSlots;
    [SerializeField] public Sprite emptySlot;
    
    [NonSerialized] public GameObject selectedItem = null;
    [NonSerialized] public int selectedItemId = -1;
    [NonSerialized] public int takenSlots = 0;

    public void SelectItem(int slotId)
    {
        if (slotId < takenSlots)
        {
            if (selectedItem != null)
            {
                selectedItem.GetComponent<Image>().color = Color.white;
            }
            selectedItem = itemSlots[slotId];
            selectedItemId = slotId;
            selectedItem.GetComponent<Image>().color = Color.red;
        }
    }

    public void RemoveItem(int slotId)
    {
        if (slotId < takenSlots)
        {
            if (slotId == selectedItemId)
            {
                selectedItem = null;
                selectedItemId = -1;
            }
            
            itemSlots[slotId].GetComponent<Image>().sprite = emptySlot;
            itemSlots[slotId].GetComponent<Image>().color = Color.white;
            
            if (slotId != takenSlots - 1)
            {
                Sprite lastSprite = emptySlot;
                for (int i = takenSlots - 1; i >= slotId; i--)
                {
                    Sprite tmp = itemSlots[i].GetComponent<Image>().sprite;
                    itemSlots[i].GetComponent<Image>().sprite = lastSprite;
                    lastSprite = tmp;
                }
            }
            
            takenSlots--;
        }
    }
}
