using UnityEngine;

public class SlabScriptL2L : MonoBehaviour
{
    
    void Start()
    {
        
    }

  
    public float scrollSpeed = 1f;
    public float resetPositionX = 10f; 
    public float startPositionX = -10f; 

    void Update()
    {
        
        transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime);

      
        if (transform.position.x >= resetPositionX)
        {
            transform.position = new Vector3(startPositionX, transform.position.y, transform.position.z);
        }
    }
}

