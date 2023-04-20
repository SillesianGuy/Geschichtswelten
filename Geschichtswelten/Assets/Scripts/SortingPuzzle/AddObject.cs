using UnityEngine;
using UnityEngine.EventSystems;

public abstract class AddObject : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] public GameObject inventory;
    [SerializeField] public GameObject[] objects;

    public abstract void OnPointerClick(PointerEventData eventData);
}
