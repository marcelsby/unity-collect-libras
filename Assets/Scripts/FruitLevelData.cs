using UnityEngine;
using UnityEditor;

public class FruitLevelData : MonoBehaviour
{
    private static int fruitsToBeCollected;
    [SerializeField] private SceneAsset nextLevel;

    public static int FruitsToBeCollected { get { return fruitsToBeCollected; } }
    public static int FruitsCollected { get; set; }
    public static string NextLevelName { get; set; }
    
    void Start()
    {
        fruitsToBeCollected = GameObject.FindWithTag("CollectiblesGrouper").transform.childCount;
        NextLevelName = nextLevel.name;
    }

    public static bool IsAllFruitsCollected()
    {
        return fruitsToBeCollected == FruitsCollected;
    }
}
