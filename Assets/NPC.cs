using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public Vector3 directionVector;
    Transform myTransform;
    Rigidbody2D rb;
    public float speed;
    public float currentSpeed;
    public bool duvaraDeyiyor = false;
    public bool playernpcTemas = false;
    public bool dilayogPenceresiAcik = false;
    public bool konusmaVar = false;
    
    Animator anim;

    public Text npcSpeak;
    public GameObject diyalogPenceresi;

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
        if (playernpcTemas)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                diyalogPenceresi.SetActive(true);
            }



        }





        //else if(diyalogPenceresi.active == true)
        //{
        //    if (Input.GetKey(KeyCode.Space))
        //    {
        //        diyalogPenceresi.SetActive(false);

        //    }
        //}

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




    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "carpma")
    //    {
    //        ChangeDirection();
    //    }
    //}

    private void OnCollisionStay2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "Player")
        {
            if (!konusmaVar)
            {
                Debug.Log("as");
                directionVector = Vector3.zero;
                anim.SetBool("temas", true);
                playernpcTemas = true;

            }


        }

        else if (collision.gameObject.tag == "carpma" || collision.gameObject.tag == "Enemy")
        {
            if (!konusmaVar)
            {
                ChangeDirection();
            }

        }


    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!konusmaVar)
            {
                ChangeDirection();
            }
            UpdateAnimation();
            StartCoroutine(ColliderAktiflestirme());
            anim.SetBool("temas", false);
            playernpcTemas = false;
            diyalogPenceresi.SetActive(false);
            konusmaVar = false;

        }
    }

    void UpdateAnimation()
    {
        anim.SetFloat("MoveX", directionVector.x);
        anim.SetFloat("MoveY", directionVector.y);

    }

    
    public IEnumerator ColliderAktiflestirme()
    {
        yield return new WaitForSeconds(0.8f);
        GetComponent<CircleCollider2D>().enabled = true;
    }
    


}

