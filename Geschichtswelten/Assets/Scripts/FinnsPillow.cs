using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FinnsPillow : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject inventory;
    [SerializeField] private Sprite openPillow;
    [SerializeField] private GameObject fetzen3;
    [SerializeField] private GameObject dialog;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        Inventory inventoryScript = inventory.GetComponent<Inventory>();

        if (inventoryScript.selectedItem == null)
        {
            return;
        }

        if (inventoryScript.selectedItem.GetComponent<Image>().sprite.name == "Messerchen")
        {
            gameObject.GetComponent<Image>().sprite = openPillow;
            fetzen3.SetActive(true);
            inventoryScript.RemoveItem(inventoryScript.selectedItemId);
            if (dialog != null)
            {
                Destroy(dialog);
                GameData.Instance.InDialog = false;
            }
        }
    }
}    
