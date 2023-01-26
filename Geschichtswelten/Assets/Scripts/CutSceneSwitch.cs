using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CutSceneSwitch : MonoBehaviour
{
    [SerializeField] private GameObject[] switchObject;
    [SerializeField] private int seconds;
    
    private void Awake()
    {
        StartCoroutine(WaitTillSwitch());
    }

    private IEnumerator WaitTillSwitch()
    {
        yield return new WaitForSeconds(seconds);
        foreach (var gameObj in switchObject)
        {
            gameObj.SetActive(true);
        }
        gameObject.SetActive(false);
    }
} 
