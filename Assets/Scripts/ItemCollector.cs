using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int cherriesCollected = 0;

    [SerializeField] private Text cherriesCounterText;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            Destroy(collision.gameObject);
            cherriesCollected++;

            cherriesCounterText.text = "Cherries: " + cherriesCollected;
        }
    }
}
