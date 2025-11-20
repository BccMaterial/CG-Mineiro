using UnityEngine;
using UnityEngine.SceneManagement;

public class floorrTransitionScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private string nextSceneName = "level1";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            SceneManager.LoadScene(nextSceneName);
    }
}
