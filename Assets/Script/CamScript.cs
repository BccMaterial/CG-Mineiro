using UnityEngine;

public class CamScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float speed = 0.1f;
    public Transform player;
    public Vector3 offset = Vector3.zero;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 movement = new Vector3(0, 1, 0) * speed * Time.deltaTime;
        transform.Translate(movement);
        camera se move pra cima
        */
        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z); // Camera follows the player with specified offset position
    }
}
