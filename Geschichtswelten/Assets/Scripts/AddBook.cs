
using UnityEngine;using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AddBook : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject book1;
    [SerializeField] private GameObject book2;
    [SerializeField] private GameObject book3;
    [SerializeField] private GameObject book4;
    [SerializeField] private GameObject book5;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        Inventory inventoryScript = inventory.GetComponent<Inventory>();

        if (inventoryScript.selectedItem == null)
        {
            return;
        }
        
        switch (inventoryScript.selectedItem.GetComponent<Image>().sprite.name)
        {
            case "Buch1Sprite":
                book1.SetActive(true);
                inventoryScript.RemoveItem(inventoryScript.selectedItemId);
                break;
            case "Buch2Sprite":
                book2.SetActive(true);
                inventoryScript.RemoveItem(inventoryScript.selectedItemId);
                break;
            case "Buch3Sprite":
                book3.SetActive(true);
                inventoryScript.RemoveItem(inventoryScript.selectedItemId);
                break;
            case "Buch4Sprite":
                book4.SetActive(true);
                inventoryScript.RemoveItem(inventoryScript.selectedItemId);
                break;
            case "Buch5Sprite":
                book5.SetActive(true);
                inventoryScript.RemoveItem(inventoryScript.selectedItemId);
                break;
        }
    }
}
