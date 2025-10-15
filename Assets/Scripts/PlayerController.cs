using System;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;
    public float jumpHeight;
    public float groundDistance;
    public bool isGrounded;
    public bool isJumping;
    public bool boomerangThrown;
    public float boomerangCooldown;

    public Animator anim;

    public Transform groundCheckObj;
    public Transform boomerangThrowPos;

    public LayerMask layerMask;

    [SerializeField] GameManager gameManger;
    [SerializeField] GameObject boomerang;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isJumping", isJumping);

        GroundCheck();

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.F) && boomerangThrown == false)
        {
            boomerangThrow();
        }

    }

    //JUMP SCRIPT
    void Jump()
    {
        rb.AddForce(Vector2.up * jumpHeight);
    }



    //CHECKS IF GROUND IS UNDER PLAYER, IF YES THEN IS GROUNDED = TRUE ALLOWING PLAYING TO JUMP.
    void GroundCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundCheckObj.position, Vector2.down, groundDistance, layerMask);
        if(hit.collider != null)
        {
            Debug.Log("Raycast found something");
            isGrounded = true;

            if (isJumping == true)
            {
                isJumping = false;
            }
        }
        else
        {
            Debug.Log("Raycast did not find something");
            isGrounded = false;
            isJumping = true;
        }
    }

    
    // Boomerang spawning script
    void boomerangThrow()
    {
        Instantiate(boomerang, boomerangThrowPos.position, Quaternion.identity);
        boomerangThrown = true;
        StartCoroutine(boomerangCooldownTimer());
    }

    // Boomerang destroying script
    IEnumerator boomerangCooldownTimer()
    {
        yield return new WaitForSeconds(boomerangCooldown);
        boomerangThrown = false;
    }




    //DAMAGE COLLISION SCRIPT: detects collision with damage brick then activates damage script in GameManager
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("TouchDamage"))
        {
            gameManger.playerDamaged();
        }
    }
}
