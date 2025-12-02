using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 5f;
    public float jmpForce = 1f;
    public int maxJumps;
    private int jumpsLeft;
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsLeft = maxJumps;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * speed * Time.deltaTime;
        transform.Translate(movement);

        if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0)
        {
            rb.linearVelocityY = 0;
            rb.AddForce(Vector2.up * jmpForce, ForceMode2D.Impulse);
            jumpsLeft--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            jumpsLeft = maxJumps; // Reseta os pulos quando toca no chão
        }
    }
}
