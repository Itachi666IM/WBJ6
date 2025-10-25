using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    bool nextLevelAccess = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            nextLevelAccess = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            nextLevelAccess = false;
        }
    }

    private void Update()
    {
        if(nextLevelAccess)
        {
            if(Keyboard.current.eKey.wasPressedThisFrame)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
