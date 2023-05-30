using UnityEngine;

public class LibrasLetter : MonoBehaviour
{
    [SerializeField] private char letter;

    public char Letter { get { return char.ToLower(letter); } }
}
