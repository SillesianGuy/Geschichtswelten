
using UnityEngine;

public class DialogDestroy : MonoBehaviour
{
    [SerializeField] private GameObject dialogActivator;
    [SerializeField] private GameObject[] destroyObject;
    private void Awake()
    {
        DialogSystem.OnDialogEnd += Switch;
    }

    private void Switch()
    {
        if (GameData.Instance.FinishedDialogs.Contains(dialogActivator.GetComponent<DialogActivator>().dialogID))
        {
            foreach (var gameObj in destroyObject)
            {
                Destroy(gameObj);
            }
            gameObject.SetActive(false);
            DialogSystem.OnDialogEnd -= Switch;   
        }
    }
}    
