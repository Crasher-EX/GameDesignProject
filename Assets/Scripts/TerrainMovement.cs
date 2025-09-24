using UnityEngine;

public class TerrainMovement : MonoBehaviour
{
    [SerializeField] float speed;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * speed;
        if(transform.position.x <= -25)
        {
            Destroy(gameObject);
        }
    }
}
