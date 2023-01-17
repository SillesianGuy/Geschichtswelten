using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BookPuzzle : MonoBehaviour, IDragHandler
{
    [SerializeField] private Transform[] fixTransform;

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

        if (minDistance < 50)
        {
            transform.position = fixTransform[index].position;
        }
    }
    
}
