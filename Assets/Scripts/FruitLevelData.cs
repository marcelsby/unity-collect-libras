using UnityEngine;
using UnityEditor;

public class FruitLevelData : MonoBehaviour
{
    [SerializeField] private SceneAsset nextLevel;
    [SerializeField] private string fruitName;

    private static int fruitsToBeCollected;

    public static int FruitsToBeCollected { get { return fruitsToBeCollected; } }
    public static int FruitsCollected { get; set; }
    public static string NextLevelName { get; set; }
    public static string FruitName { get; set; }
    
    void Start()
    {
        fruitsToBeCollected = GameObject.FindWithTag("CollectiblesGrouper").transform.childCount;
        NextLevelName = nextLevel.name;
        FruitName = fruitName;
    }

    public static bool IsAllFruitsCollected()
    {
        return fruitsToBeCollected == FruitsCollected;
    }
}
