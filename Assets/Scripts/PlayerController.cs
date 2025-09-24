using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;
    public float jumpHeight;
    public float groundDistance;
    public bool isGrounded;

    public Transform groundCheckObj;

    public LayerMask layerMask;


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

        GroundCheck();

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            Jump();
        }
    }


    void Jump()
    {
        rb.AddForce(Vector2.up * jumpHeight);
    }

    void GroundCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundCheckObj.position, Vector2.down, groundDistance, layerMask);
        if(hit.collider != null)
        {
            Debug.Log("Raycast found something");
            isGrounded = true;
        }
        else
        {
            Debug.Log("Raycast did not find something");
            isGrounded = false;
        }
    }
}
