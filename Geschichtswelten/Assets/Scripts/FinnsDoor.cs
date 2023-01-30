using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FinnsDoor : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject finnsRoom;
    [SerializeField] private GameObject gang;
    [SerializeField] private GameObject dialog;
    
    private bool _opened = false;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        Inventory inventoryScript = inventory.GetComponent<Inventory>();

        if (_opened)
        {
            if(!GameData.Instance.InDialog) {
                finnsRoom.SetActive(true);
                gang.SetActive(false);
            }
            return;
        }
        
        if (inventoryScript.selectedItem == null)
        {
            return;
        }

        if (!_opened)
        {
            if (inventoryScript.selectedItem.GetComponent<Image>().sprite.name == "SchlüsselFinnsZimmer")
            {
                _opened = true;
                if (!GameData.Instance.InDialog)
                {
                    Destroy(dialog);
                    finnsRoom.SetActive(true);
                    gang.SetActive(false);
                }
                inventoryScript.RemoveItem(inventoryScript.selectedItemId);
            }
        }
    }
}
