using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;
    private bool isTakingDamage = false;
    // private bool isDead = false;
    private Animator animator;
    private HealthUI healthUI;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        healthUI = FindObjectOfType<HealthUI>();
        healthUI.AtualizarVida(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isTakingDamage && collision.collider.CompareTag("Enemy"))
        {
            StartCoroutine(TakeDamageOverTime());
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            isTakingDamage = false;
        }
    }

    // void OnTriggerEnter2D(Collider2D collision)
    // {
    //     // Debug.Log("ENTER");
        
    //     // if (collision.CompareTag("Enemy") && !isTakingDamage)
    //     if (!isTakingDamage && collision.CompareTag("Enemy") && collision.IsTouching(GetComponent<Collider2D>()))
    //     {
    //         StartCoroutine(TakeDamageOverTime());
    //     }
    // }

    // void OnTriggerExit2D(Collider2D collision)
    // {
    //     // Debug.Log("EXIT");

    //     if (collision.CompareTag("Enemy"))
    //     {
    //         isTakingDamage = false;
    //     }

    // }

    IEnumerator TakeDamageOverTime()
    {
        isTakingDamage = true;

        while (isTakingDamage && currentHealth > 0)
        {
            currentHealth--;
            healthUI.AtualizarVida(currentHealth);
            // Debug.Log("Vida: " + currentHealth);

            if (currentHealth <= 0)
            {
                // Debug.Log("Player morreu!");
                Die();
                // Aqui você pode chamar uma função de Game Over, etc.
                break;
            }

            yield return new WaitForSeconds(1f); // espera 1 segundo
        }
    }

    void Die()
    {
        
        // isDead = true;
        animator.SetTrigger("Death");

        Transform axe = transform.Find("axe");
        if (axe != null)
        {
            axe.gameObject.SetActive(false); // ou Destroy(axe.gameObject);
        }

        // Desativar movimentação ou outras ações
        GetComponent<PlayerMoviment>().enabled = false;
        Collider2D col = GetComponent<Collider2D>();
        if (col != null) col.enabled = false;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.isKinematic = true; // deixa de ser afetado pela física
        }
        

        StartCoroutine(RestartGame());
        // Se quiser remover o player da cena depois de um tempo:
        // Destroy(gameObject, 2f); // Espera 2 segundos antes de destruir
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(5f); // espera a animação terminar
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
