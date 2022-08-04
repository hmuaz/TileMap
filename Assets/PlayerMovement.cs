using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    public Animator animator;
    public Vector3 karakterinPozisyonu;
    public Camera cam;

    void Update()
    {
        karakterinPozisyonu = transform.position;

        if(karakterinPozisyonu.y < -5)
        {

        }


       movement.x = Input.GetAxisRaw("Horizontal");
       movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
