using UnityEngine;
using TMPro;

public class FruitCollector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fruitsCollectedCounter;

    void Start()
    {
        UpdateFruitsCollectedText();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Transform parent = collision.gameObject.transform.parent;

        if (parent != null && parent.CompareTag("CollectiblesGrouper"))
        {
            Destroy(collision.gameObject);
            FruitLevelData.FruitsCollected++;

            UpdateFruitsCollectedText();
        }
    }

    private void UpdateFruitsCollectedText()
    {
            fruitsCollectedCounter.text = $"{FruitLevelData.FruitName}: {FruitLevelData.FruitsCollected} / {FruitLevelData.FruitsToBeCollected}";
    }
}
