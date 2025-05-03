using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeHit : MonoBehaviour
{
    // private bool isAttacking = false;
    private BoxCollider2D boxCollider;

    private PontuacaoUI pontuacaoUI;
    private int pontuacao = 0;
    // void Start(){
    //     healthUI = FindObjectOfType<HealthUI>();
    //     healthUI.AtualizarVida(currentHealth);
    // }

    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        // circleCollider.enabled = false;

        pontuacaoUI = FindObjectOfType<PontuacaoUI>();
        // pontuacaoUI.AtualizarPontuacao(currentHealth);
    }

    // public void AtivarColliderHorizontal()
    // {
    //     boxCollider.enabled = true;
    //     boxCollider.size = new Vector2(0.12f, 0.1f); // menos largo (reduz "alcance")
    //     boxCollider.offset = new Vector2(0.06f, 0f); // puxa mais próximo do player
    // }
    // Chamada no fim da animação
    // public void DesativarColliderOuReset()
    // {
    //     boxCollider.enabled = false;
    //     boxCollider.size = new Vector2(0.1399695f, 0.2825976f);
    //     boxCollider.offset = new Vector2(-0.004130725f, -0.01803306f);
    // }

    // public void StartAttack()
    // {
    //     isAttacking = true;
    //     // circleCollider.enabled = true;
    // }

    // public void EndAttack()
    // {
    //     isAttacking = false;
    //     // circleCollider.enabled = false;
    // }

    // private void OnCollisionExit2D(Collision2D collision)
    // {
    //     if (collision.CompareTag("Enemy"))
    //     {

    //         Destroy(collision.gameObject);
    //         pontuacao++;
    //         pontuacaoUI.AtualizarPontuacao(pontuacao);
    //     }
    // }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {

            Destroy(collision.gameObject);
            pontuacao++;
            pontuacaoUI.AtualizarPontuacao(pontuacao);
        }
    }
}
