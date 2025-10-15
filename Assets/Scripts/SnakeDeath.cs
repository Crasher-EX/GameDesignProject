using UnityEngine;

public class SnakeDeath : MonoBehaviour
{
    public GameObject snake;
    public GameObject snakeDamageBox;
    public Animator snakeAnim;
    public bool snakeDead;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        snakeAnim.SetBool("snakeDead", snakeDead);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boomerang"))
        {
            snake.GetComponent<Rigidbody2D>().gravityScale = 1; //makes snake have gravity to fall out of map();
            snakeDead = true;
            Destroy(snakeDamageBox);
        }
    }
}
