using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    public void Die()
    {
        anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(FruitLevelData.NextLevelName);
    }
}
