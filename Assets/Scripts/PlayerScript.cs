using UnityEngine;
using UnityEngine.SceneManagement;

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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            int scenesCount = SceneManager.sceneCountInBuildSettings;
            Debug.Log($"Next Scene: {nextSceneIndex}, Scenes Count: {scenesCount}");
            if(nextSceneIndex >= scenesCount)
            {
                SceneManager.LoadScene("Menu");
            }
            else
            {
                SceneManager.LoadScene(nextSceneIndex);
            }

        }

        if (collision.gameObject.CompareTag("Floor") && collision.contacts[0].normal.y > 0.5f)
        {
            jumpsLeft = maxJumps;
        }
        
        if (collision.gameObject.CompareTag("MovingPlatform") && collision.contacts[0].normal.y > 0.5f)
        {
            transform.parent = collision.transform;
            jumpsLeft = maxJumps;
        }

        if (collision.gameObject.CompareTag("Lava"))
        {
            SceneManager.LoadScene("GameOver");
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