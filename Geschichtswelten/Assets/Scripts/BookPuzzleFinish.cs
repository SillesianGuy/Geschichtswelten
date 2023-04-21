using System;
using UnityEngine;
using UnityEngine.Serialization;

public class BookPuzzleFinish : MonoBehaviour
{
    [SerializeField] private GameObject[] correctBookOrder;
    [SerializeField] private GameObject[] snaps;
    [SerializeField] private GameObject dialog;
    [SerializeField] private bool gameFinish;
    public delegate void GameFinished();
    public static event GameFinished OnGameFinished;

    private void Awake()
    {
        SortingPuzzle.OnPuzzleSnapped += PuzzleCheck;
        AddFetzen.OnFetzenAdded += PuzzleCheck;
    }

    private void PuzzleCheck()
    {
        bool result = true;
        for (int i = 0; i < correctBookOrder.Length; i++)
        {
            if (snaps[i].GetComponent<Snap>().obj != correctBookOrder[i] || !correctBookOrder[i].activeSelf)
            {
                result = false;
            }
        }

        if (result)
        {
            SortingPuzzle.OnPuzzleSnapped -= PuzzleCheck;
            AddFetzen.OnFetzenAdded -= PuzzleCheck;
            if(gameFinish) {
                Debug.Log("test2");
                OnGameFinished?.Invoke();
            }
            dialog.SetActive(true);
            GameData.Instance.InDialog = true;
        }
    }
}    
