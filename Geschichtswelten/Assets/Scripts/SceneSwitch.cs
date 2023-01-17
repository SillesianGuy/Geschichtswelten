using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int sceneID;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadSceneAsync(sceneID);
    }
}
