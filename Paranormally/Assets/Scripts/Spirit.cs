using UnityEngine;

public class Spirit : MonoBehaviour
{
    GhostMode ghostMode;
    private void Awake()
    {
        ghostMode = FindAnyObjectByType<GhostMode>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            ghostMode.canUseGhostMode = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            ghostMode.canUseGhostMode = false;
        }
    }
}
