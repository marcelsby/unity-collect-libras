using UnityEngine;
using TMPro;

public class ToggleMessage : MonoBehaviour
{
    [SerializeField] private GameObject message;

    void OnTriggerEnter2D()
    {
        message.SetActive(true);
    }

    void OnTriggerExit2D()
    {
        message.SetActive(false);
    }
}
