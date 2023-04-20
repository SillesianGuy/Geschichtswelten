using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AddBook : AddObject
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        Inventory inventoryScript = inventory.GetComponent<Inventory>();

        if (inventoryScript.selectedItem == null)
        {
            return;
        }
        
        switch (inventoryScript.selectedItem.GetComponent<Image>().sprite.name)
        {
            case "Buch1Sprite":
                objects[0].SetActive(true);
                inventoryScript.RemoveItem(inventoryScript.selectedItemId);
                break;
            case "Buch2Sprite":
                objects[1].SetActive(true);
                inventoryScript.RemoveItem(inventoryScript.selectedItemId);
                break;
            case "Buch3Sprite":
                objects[2].SetActive(true);
                inventoryScript.RemoveItem(inventoryScript.selectedItemId);
                break;
            case "Buch4Sprite":
                objects[3].SetActive(true);
                inventoryScript.RemoveItem(inventoryScript.selectedItemId);
                break;
            case "Buch5Sprite":
                objects[4].SetActive(true);
                inventoryScript.RemoveItem(inventoryScript.selectedItemId);
                break;
        }
    }
}
