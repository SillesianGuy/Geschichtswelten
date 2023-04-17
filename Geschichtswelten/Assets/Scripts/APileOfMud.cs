using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class APileOfMud : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject inventory;
    [SerializeField] private Sprite aPileOfMudNaked;
    [SerializeField] private GameObject dialog;
    [SerializeField] private GameObject[] enableObjects;
    [SerializeField] private string itemName;

    public void OnPointerClick(PointerEventData eventData)
    {
        Inventory inventoryScript = inventory.GetComponent<Inventory>();

        if (inventoryScript.selectedItem == null)
        {
            return;
        }

        if (inventoryScript.selectedItem.GetComponent<Image>().sprite.name == itemName)
        {
            gameObject.GetComponent<Image>().sprite = aPileOfMudNaked;

            foreach (var obj in enableObjects)
            {
                obj.SetActive(true);
            }
            
            inventoryScript.RemoveItem(inventoryScript.selectedItemId);
            if (dialog != null)
            {
                Destroy(dialog);
                GameData.Instance.InDialog = false;
            }
        }
    }
}    
