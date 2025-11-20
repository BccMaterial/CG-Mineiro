using UnityEngine;

public class LavaScript : MonoBehaviour
{
    public float speed = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 newScale = transform.localScale;
        //newScale.y *= 1.2f; 
       // transform.localScale = newScale;
        //public float scaleSpeed = 1f;
   
        // Example: Gradually increase scale
        //if (transform.localScale.x < 3f)
        //{
            //transform.localScale += Vector3.one * scaleSpeed * Time.deltaTime;
        //}
    
    transform.Translate(Vector3.up * speed * Time.deltaTime);
}
}
