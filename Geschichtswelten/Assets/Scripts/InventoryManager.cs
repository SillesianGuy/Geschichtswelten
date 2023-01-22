using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    
    public Transform ItemContent;
    public GameObject InventoryItem;

    private void Awake() {
        Instance = this;
    }

    public void Add(Item item) {
        GameData.Instance.Items.Add(item);
    }

    public void Remove(Item item) {
        GameData.Instance.Items.Remove(item);
    }

    public void ListItems() {
        foreach (var item in GameData.Instance.Items) {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            itemIcon.sprite = item.icon;
        }
    }
}
