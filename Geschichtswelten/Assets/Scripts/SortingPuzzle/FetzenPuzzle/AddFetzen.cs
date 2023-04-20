using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AddFetzen : AddObject
{
    public delegate void FetzenAdded();
    public static event FetzenAdded OnFetzenAdded;
    
    public override void OnPointerClick(PointerEventData eventData)
    {
        Inventory inventoryScript = inventory.GetComponent<Inventory>();

        if (inventoryScript.selectedItem == null)
        {
            return;
        }
        
        switch (inventoryScript.selectedItem.GetComponent<Image>().sprite.name)
        {
            case "Fetzen1":
                objects[0].SetActive(true);
                inventoryScript.RemoveItem(inventoryScript.selectedItemId);
                OnFetzenAdded?.Invoke();
                break;
            case "Fetzen2":
                objects[1].SetActive(true);
                objects[3].SetActive(true);
                objects[4].SetActive(true);
                objects[5].SetActive(true);
                OnFetzenAdded?.Invoke();
                inventoryScript.RemoveItem(inventoryScript.selectedItemId);
                break;
            case "Fetzen3":
                objects[2].SetActive(true);
                OnFetzenAdded?.Invoke();
                inventoryScript.RemoveItem(inventoryScript.selectedItemId);
                break;
        }
    }
}
