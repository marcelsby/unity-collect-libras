using TMPro;
using UnityEngine;

public class LibrasLetterCollector : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private LibrasChallengeController challengeController;
    [SerializeField] private TextMeshProUGUI collectedLettersText;
    [SerializeField] private GameObject winMessage;
    
    private PlayerLife pl;

    void Start()
    {
        pl = GetComponent<PlayerLife>();
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LibrasLetter"))
        {
            char collectedLetter = collision.gameObject.GetComponent<LibrasLetter>().Letter;

            LibrasLetterCollectionStatus collectionStatus = challengeController.CollectLetterInOrder(collectedLetter);

            if (collectionStatus.Equals(LibrasLetterCollectionStatus.Valid))
            {
                Destroy(collision.gameObject);
                UpdateCollectedLettersText(collectedLetter);
            }
            else if (collectionStatus.Equals(LibrasLetterCollectionStatus.Invalid))
            {
                pl.Die();
            }
            else if (collectionStatus.Equals(LibrasLetterCollectionStatus.Win))
            {
                UpdateCollectedLettersText(collectedLetter);
                rb.bodyType = RigidbodyType2D.Static;
                winMessage.SetActive(true);
            }
        }
    }

    private void UpdateCollectedLettersText(char collectedLetter)
    {
        collectedLettersText.text += $"{char.ToUpper(collectedLetter)} ";
    }
}
