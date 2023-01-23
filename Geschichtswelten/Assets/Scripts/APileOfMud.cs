using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class APileOfMud : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject inventory;
    [SerializeField] private Sprite aPileOfMudNaked;
    [SerializeField] private GameObject book;


    public void OnPointerClick(PointerEventData eventData)
    {
        Inventory inventoryScript = inventory.GetComponent<Inventory>();

        if (inventoryScript.selectedItem == null)
        {
            return;
        }

        if (inventoryScript.selectedItem.GetComponent<Image>().sprite.name == "Schaufel")
        {
            gameObject.GetComponent<Image>().sprite = aPileOfMudNaked;
            book.SetActive(true);
            inventoryScript.RemoveItem(inventoryScript.selectedItemId);
        }
    }
}    
