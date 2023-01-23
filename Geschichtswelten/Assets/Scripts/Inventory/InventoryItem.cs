using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject inventory;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        Inventory inventoryScript = inventory.GetComponent<Inventory>();

        if (inventoryScript.takenSlots < inventoryScript.itemSlots.Length)
        {
            inventoryScript.itemSlots[inventoryScript.takenSlots].GetComponent<Image>().sprite = gameObject.GetComponent<Image>().sprite;
            
            gameObject.SetActive(false);
            
            inventoryScript.takenSlots++;
        }
    }
}
