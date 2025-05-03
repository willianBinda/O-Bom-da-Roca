using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Transform player;
    public float speed = 2f;
    private Animator animator;
    private bool facingRight = true;
    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();

        // Ativa perseguição ao spawnar
        // if (player != null)
        // {
        //     ChasePlayer();
        // }
    }

    void Update()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;

            // Movimenta o inimigo
            // transform.position += (Vector3)direction * speed * Time.deltaTime;
            Vector2 newPosition = rb.position + direction * speed * Time.deltaTime;
            rb.MovePosition(newPosition);

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
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1f;
        transform.localScale = scale;
    }
}

