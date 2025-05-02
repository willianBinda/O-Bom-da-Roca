using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator animator;
    private bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // axeAnimator = transform.Find("axe").GetComponent<Animator>();
        animator = GetComponent<Animator>();
 
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        // Debug.Log("MOvimento x " + movement.x + " MOvimento Y " + movement.y);

        animator.SetFloat("Speed", Mathf.Abs(movement.magnitude));

        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     axeAnimator.SetTrigger("attack");
        // }

        if ((Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.LeftArrow)) && facingRight)
        {
            Flip(); // vira para esquerda
        }
        else if ((Input.GetKeyDown(KeyCode.D)|| Input.GetKeyDown(KeyCode.RightArrow)) && !facingRight)
        {
            Flip(); // vira para direita
        }
       
    }

    void FixedUpdate()
    {
        // Movimento do player
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1f;
        transform.localScale = scale;

        // Debug.Log("Flip executado. Novo scale: " + transform.localScale);
    }
}