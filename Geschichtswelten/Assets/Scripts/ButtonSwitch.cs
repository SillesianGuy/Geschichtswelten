using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSwitch : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private GameObject switchObject;
    [SerializeField] private GameObject currentObject;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!GameData.Instance.InDialog)
        {
            currentObject.SetActive(false);
            switchObject.SetActive(true);
        }
    }
}
    
