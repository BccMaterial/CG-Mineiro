using UnityEngine;

public enum ScrollDirection
{
    Right = 1,
    Left = -1
}

public class SlabMovingScript : MonoBehaviour
{
    [Header("Movement Settings")]
    public float scrollSpeed = 2f;
    public ScrollDirection startDirection = ScrollDirection.Right;
    public float movementRange = 10f; // Distância total de movimento
    
    private Vector3 startPosition;
    private float directionMultiplier = 1f;
    private float timer = 0f;

    void Start()
    {
        startPosition = transform.position;
        
        //
        if (startDirection == ScrollDirection.Left)
        {
            // Começa do lado direito se a direção inicial for esquerda
            timer = movementRange / scrollSpeed;
            directionMultiplier = -1f;
        }
    }

    void Update()
    {
        timer += Time.deltaTime * directionMultiplier;
        // Usa PingPong para movimento oscilante
        float pingPongValue = Mathf.PingPong(timer * scrollSpeed, movementRange);
        
        // Aplica movimento baseado na direção inicial
        transform.position = new Vector3(
                startPosition.x + pingPongValue,
                transform.position.y,
                transform.position.z
            );
    }
}