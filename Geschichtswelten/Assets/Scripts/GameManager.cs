using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    public float currentVolume;

    void Awake()
    {
        currentVolume = 100;
    }

    void Update()
    {
        
    }
}
