using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CutSceneSwitch : MonoBehaviour
{
    [SerializeField] private GameObject[] switchObject;
    [SerializeField] private int seconds;
    [SerializeField] private bool scene;
    [SerializeField] private int sceneId;
    
    private void Awake()
    {
        StartCoroutine(WaitTillSwitch());
    }

    private IEnumerator WaitTillSwitch()
    {
        yield return new WaitForSeconds(seconds);
        if(!scene) {
            foreach (var gameObj in switchObject)
            {
                gameObj.SetActive(true);
            }
            gameObject.SetActive(false);
        }
        else
        {
            SceneManager.LoadSceneAsync(sceneId);
        }
    }
} 
