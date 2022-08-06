 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private Vector3 directionVector;
    Transform myTransform;
    Rigidbody2D rb;
    public float speed;
    public float currentSpeed;
    public bool duvaraDeyiyor = false;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        myTransform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        ChangeDirection();

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }


    private void FixedUpdate()
    {
        Move();
    }
    void ChangeDirection()
    {
        int direction = Random.Range(0, 4);
        switch (direction)
        {
            case 0:
                directionVector = Vector3.right;
                break;
            case 1:
                directionVector = Vector3.left;
                break;
            case 2:
                directionVector = Vector3.up;
                break;
            case 3:
                directionVector = Vector3.down;
                break;

            default:
                break;
        }
        UpdateAnimation();
    }

    void Move()
    {
        rb.MovePosition(myTransform.position + directionVector * speed * Time.deltaTime);
    }


    IEnumerator DuvaraTakiliKalma()
    {
        Debug.Log("he");
        yield return new WaitForSeconds(1);
        ChangeDirection();

        
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "carpma")
    //    {
    //        ChangeDirection();
    //    }
    //}

    private void OnCollisionStay2D(Collision2D collision)
    {
        

        if(collision.gameObject.tag == "Player")
        {
            directionVector = Vector3.zero;
        }

        else if (collision.gameObject.tag == "carpma" || collision.gameObject.tag == "Enemy")
        {
            ChangeDirection();
        }


    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ChangeDirection();
        }
    }

    void UpdateAnimation()
    {
        anim.SetFloat("MoveX", directionVector.x);
        anim.SetFloat("MoveY", directionVector.y);

    }
}

