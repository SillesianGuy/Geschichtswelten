using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BookPuzzle : MonoBehaviour, IDragHandler
{
    [SerializeField] private Transform[] fixTransform;
    [SerializeField] private Transform current;
    
    public delegate void PuzzleSnapped();
    public static event PuzzleSnapped OnPuzzleSnapped;
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        
        float minDistance = -1;
        int index = -1;
        
        for (int i = 0; i < fixTransform.Length; i++)
        {
            Vector2 fixPosition = new Vector2(fixTransform[i].position.x, fixTransform[i].position.y);
            Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);

            float distance = Vector2.Distance(fixPosition, currentPosition);

            if (minDistance == -1f)
            {
                minDistance = distance;
                index = i;
            }

            if (distance < minDistance)
            {
                minDistance = distance;
                index = i;
            }
        }

        if (minDistance < 40)
        {
            if (fixTransform[index] != current)
            {
                GameObject snapBookExtern = fixTransform[index].GetComponentInParent<BookSnap>().book;
                GameObject snapBookIntern = current.GetComponentInParent<BookSnap>().book;
                
                fixTransform[index].GetComponentInParent<BookSnap>().book = snapBookIntern;
                current.GetComponentInParent<BookSnap>().book = snapBookExtern;
                
                snapBookIntern.transform.position = fixTransform[index].position;
                StartCoroutine(SpawnTrail(snapBookExtern, current.transform.position));


                Transform tmp = current;
                current = fixTransform[index];
                snapBookExtern.GetComponent<BookPuzzle>().current = tmp;

                OnPuzzleSnapped?.Invoke();
            }

            gameObject.transform.position = current.position;
        }
    }
    
    private IEnumerator SpawnTrail(GameObject objectToMove, Vector3 targetPosition)
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
