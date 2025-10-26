using UnityEngine;
using UnityEngine.SceneManagement;
public class Spike : MonoBehaviour
{
    SFXManager sfx;
    [SerializeField] AudioClip playerDeath;
    private void Awake()
    {
        sfx = FindAnyObjectByType<SFXManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            sfx.PlayAnyAudio(playerDeath);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
