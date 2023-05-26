using UnityEngine;

public class CrystalFinishLevel : MonoBehaviour
{
    private int fruitsToBeCollectedQuantity;

    [SerializeField] private ItemCollector collectorScript;
    [SerializeField] private GameObject unfinishedLevelWarning;


    void Start()
    {
        fruitsToBeCollectedQuantity = GameObject.FindGameObjectWithTag("CollectiblesGrouper").transform.childCount;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (FruitLevelData.IsAllFruitsCollected())
            {
                Animator playerAnim = collision.gameObject.GetComponent<Animator>();
                Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();

                playerRb.bodyType = RigidbodyType2D.Static;
                playerAnim.SetTrigger("startTeleport");
            }
            else
            {
                unfinishedLevelWarning.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            unfinishedLevelWarning.SetActive(false);
        }
    }
}
