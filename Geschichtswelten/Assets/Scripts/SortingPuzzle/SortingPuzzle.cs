using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class SortingPuzzle : MonoBehaviour, IDragHandler
{
    [SerializeField] private Transform[] snap;
    [SerializeField] private Transform currentSnap;
    [SerializeField] private int maxSnapDistance = 40;
    
    public delegate void PuzzleSnapped();
    public static event PuzzleSnapped OnPuzzleSnapped;
    
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        
        float minDistance = 0;
        int index = -1;
        
        for (int i = 0; i < snap.Length; i++)
        {
            Vector2 fixPosition = new Vector2(snap[i].position.x, snap[i].position.y);
            Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);

            float distance = Vector2.Distance(fixPosition, currentPosition);
            
            if (distance < minDistance || minDistance == 0)
            {
                minDistance = distance;
                index = i;
            }
        }

        if (minDistance < maxSnapDistance)
        {
            if (snap[index] != currentSnap)
            {
                GameObject snapObjectExtern = snap[index].GetComponentInParent<Snap>().obj;
                GameObject snapObjectIntern = currentSnap.GetComponentInParent<Snap>().obj;
                
                snap[index].GetComponentInParent<Snap>().obj = snapObjectIntern;
                currentSnap.GetComponentInParent<Snap>().obj = snapObjectExtern;
                
                snapObjectIntern.transform.position = snap[index].position;
                StartCoroutine(MoveObject(snapObjectExtern, currentSnap.transform.position));

                Transform tmp = currentSnap;
                currentSnap = snap[index];
                snapObjectExtern.GetComponent<SortingPuzzle>().currentSnap = tmp;

                OnPuzzleSnapped?.Invoke();
            }

            gameObject.transform.position = currentSnap.position;
        }
    }
    
    private IEnumerator MoveObject(GameObject objectToMove, Vector3 targetPosition)
    {
        float time = 0;
        Vector3 startPosition = objectToMove.transform.position;

        while (time < 1)
        {
            objectToMove.transform.position = Vector3.Lerp(startPosition, targetPosition, time);
            time += Time.deltaTime / 0.3f;

            yield return null;
        }
    }
}