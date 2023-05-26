using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Text cherriesCounterText;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            Destroy(collision.gameObject);
            FruitLevelData.FruitsCollected++;

            cherriesCounterText.text = $"Cherries: {FruitLevelData.FruitsCollected}";
        }
    }
}
