using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorTransitionScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string nextSceneName = "Level1";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.contacts[0].normal.y < 0.5f)
            SceneManager.LoadScene(nextSceneName);
    }
}
