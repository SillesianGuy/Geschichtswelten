using UnityEngine;
using UnityEngine.Serialization;

public class BookPuzzleFinish : MonoBehaviour
{
    [SerializeField] private GameObject[] correctBookOrder;
    [SerializeField] private GameObject[] snaps;
    [SerializeField] private GameObject dialog;

    public delegate void PuzzleFinished();
    public static event PuzzleFinished OnPuzzleFinished;

    private void Awake()
    {
        BookPuzzle.OnPuzzleSnapped += PuzzleCheck;
        AddFetzen.OnFetzenAdded += PuzzleCheck;
    }

    private void PuzzleCheck()
    {
        bool result = true;
        for (int i = 0; i < correctBookOrder.Length; i++)
        {
            if (snaps[i].GetComponent<BookSnap>().book != correctBookOrder[i])
            {
                result = false;
            }

            if (!correctBookOrder[i].activeSelf)
            {
                result = false;
            }
        }

        if (result)
        {
            BookPuzzle.OnPuzzleSnapped -= PuzzleCheck;
            AddFetzen.OnFetzenAdded -= PuzzleCheck;
            dialog.SetActive(true);
            GameData.Instance.InDialog = true;
        }
    }
}    
