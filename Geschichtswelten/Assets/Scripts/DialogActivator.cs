using UnityEngine;
using UnityEngine.EventSystems;

public class DialogActivator : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject dialogBox;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if(!GameData.Instance.InDialog) {
            dialogBox.gameObject.SetActive(true);
            GameData.Instance.InDialog = true;
        }
    }
}
