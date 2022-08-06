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
    public bool evinIcinde = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 9; 
        }
        else
        {
            speed = 5;
        }

            karakterinPozisyonu = transform.position;

        if (evinIcinde)
        {
            float camy = Mathf.Clamp(transform.position.y, 16, 20);
            cam.transform.position = new Vector3(48, camy, -10);
        }
        else
        {
            if (karakterinPozisyonu.y > -5)
            {
                float camx = Mathf.Clamp(transform.position.x, -2, 2);
                float camy = Mathf.Clamp(transform.position.y, 0, 2);

                cam.transform.position = new Vector3(camx, camy, -10);
            }

            if (karakterinPozisyonu.y < -5)
            {
                if (karakterinPozisyonu.y < -18.5f)
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

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if(trigger.gameObject.tag == "kapi")
        {
            evinIcinde = true;
            


            transform.position = new Vector3(49, 13 , 0);
        }

        if (trigger.gameObject.tag == "kapicikis")
        {
            evinIcinde = false;

            transform.position = new Vector3(3.5f, 0.58f, 0);

        }
    }

    
}
