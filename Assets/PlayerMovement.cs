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

        
        if(karakterinPozisyonu.y > -5)
        {
            float camx = Mathf.Clamp(transform.position.x, -2, 2);
            float camy = Mathf.Clamp(transform.position.y, 0, 2);

            cam.transform.position = new Vector3(camx, camy, -10);
        }

        if (karakterinPozisyonu.y < -5)
        {
            if(karakterinPozisyonu.y < -18.5f)
            {
                float camy = Mathf.Clamp(transform.position.y, -40, -23);
                float camx = Mathf.Clamp(transform.position.x, -22, 30);

                cam.transform.position = new Vector3(camx, camy, -10);
            }
            else
            {
                float camy = Mathf.Clamp(transform.position.y, -13.75f, -9.5f);
                cam.transform.position = new Vector3(0, camy, -10);
            }

            

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
