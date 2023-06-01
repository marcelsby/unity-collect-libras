using UnityEngine;
using UnityEditor;

public class FruitLevelData : MonoBehaviour
{
    [SerializeField] private int nextLevelBuildIndex;
    [SerializeField] private string fruitName;

    private static int fruitsToBeCollected;

    public static int FruitsToBeCollected { get { return fruitsToBeCollected; } }
    public static int FruitsCollected { get; set; }
    public static int NextLevelBuildIndex { get; set; }
    public static string FruitName { get; set; }
    
    void Start()
    {
        FruitsCollected = 0;
        fruitsToBeCollected = GameObject.FindWithTag("CollectiblesGrouper").transform.childCount;
        NextLevelBuildIndex = nextLevelBuildIndex;
        FruitName = fruitName;
    }

    public static bool IsAllFruitsCollected()
    {
        return fruitsToBeCollected == FruitsCollected;
    }
}
