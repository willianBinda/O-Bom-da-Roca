using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Transform player;
    public float speed = 2f;
    private Animator animator;
    private bool isChasing = false;
    private bool facingRight = true;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Debug.Log("PLAYER: " + player);
        if (isChasing && player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;

            // Movimenta o inimigo
            transform.position += (Vector3)direction * speed * Time.deltaTime;

            // Define a animação de Run com base na velocidade
            animator.SetFloat("Speed", direction.magnitude);

            // Faz o Flip da sprite se necessário
            if (direction.x > 0 && !facingRight)
            {
                Flip();
            }
            else if (direction.x < 0 && facingRight)
            {
                Flip();
            }
        }
        else
        {
            // Sem movimento = Idle
            animator.SetFloat("Speed", 0f);
        }
    }
   
    void Flip()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1f;
        transform.localScale = scale;
    }

    void OnBecameVisible()
    {
        isChasing = true;
    }

    void OnBecameInvisible()
    {
        isChasing = false;
    }

    public void SetChase(bool chase)
    {
        isChasing = chase;
    }

   
}
