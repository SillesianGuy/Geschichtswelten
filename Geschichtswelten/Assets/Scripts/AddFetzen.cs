using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AddFetzen : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject fetzen1;
    [SerializeField] private GameObject fetzen2;
    [SerializeField] private GameObject fetzen3;
    [SerializeField] private GameObject fetzen4;
    [SerializeField] private GameObject fetzen5;
    [SerializeField] private GameObject fetzen6;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        Inventory inventoryScript = inventory.GetComponent<Inventory>();

        if (inventoryScript.selectedItem == null)
        {
            return;
        }
        
        switch (inventoryScript.selectedItem.GetComponent<Image>().sprite.name)
        {
            case "Fetzen1":
                fetzen1.SetActive(true);
                inventoryScript.RemoveItem(inventoryScript.selectedItemId);
                break;
            case "Fetzen2":
                fetzen2.SetActive(true);
                fetzen4.SetActive(true);
                fetzen5.SetActive(true);
                fetzen6.SetActive(true);
                inventoryScript.RemoveItem(inventoryScript.selectedItemId);
                break;
            case "Fetzen3":
                fetzen3.SetActive(true);
                inventoryScript.RemoveItem(inventoryScript.selectedItemId);
                break;
        }
    }
}
