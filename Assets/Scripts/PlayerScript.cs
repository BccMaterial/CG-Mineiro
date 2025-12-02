using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 5f;
    public float jmpForce = 1f;
    public int maxJumps;
    
    private int jumpsLeft;
    private Rigidbody2D rb;
    private Transform originalParent; // Armazena o pai original

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsLeft = maxJumps;
        originalParent = transform.parent; // Guarda o pai inicial (geralmente a cena)
    }

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
            jumpsLeft = maxJumps;
        }
        
        // Se colidir com a plataforma móvel
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            // Verifica se está pisando na plataforma (colisão pelo topo)
            if (collision.contacts[0].normal.y > 0.5f)
            {
                // Torna a plataforma "pai" do player
                transform.parent = collision.transform;
                jumpsLeft = maxJumps; // Reseta pulos também na plataforma
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Quando sair da plataforma, remove o parentesco
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            transform.parent = originalParent;
        }
    }
}