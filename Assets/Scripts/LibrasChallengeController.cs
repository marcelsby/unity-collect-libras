using UnityEngine;

public enum LibrasLetterCollectionStatus
{
    Valid,
    Invalid,
    Win,
}

public class LibrasChallengeController : MonoBehaviour
{
    [SerializeField] private string expectedWord;
    
    private int nextLetterIndex = 0;

    void Start()
    {
        expectedWord = expectedWord.ToLower().Trim();
    }

    public LibrasLetterCollectionStatus CollectLetterInOrder(char collectedLetter)
    {
        Debug.Log($"Collected letter: {collectedLetter}");
        Debug.Log($"Expected letter: {expectedWord[nextLetterIndex]}");

        char expectedLetter = expectedWord[nextLetterIndex];

        if (collectedLetter != expectedLetter)
        {
            return LibrasLetterCollectionStatus.Invalid;
        } 
        else 
        {
            if (nextLetterIndex + 1 >= expectedWord.Length)
            {
                return LibrasLetterCollectionStatus.Win;
            }
            else
            {
                nextLetterIndex++;
                return LibrasLetterCollectionStatus.Valid;
            }
        }
    }
}
