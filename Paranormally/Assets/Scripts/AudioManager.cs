using UnityEngine;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{
    AudioSource myAudio;
    [SerializeField] private AudioClip menuSong;
    [SerializeField] private AudioClip cutsceneSong;
    [SerializeField] private AudioClip gameSong;
    void ManageSingleton()
    {
        int instance = FindObjectsByType<AudioManager>(FindObjectsSortMode.None).Length;
        if(instance > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Awake()
    {
        myAudio = GetComponent<AudioSource>();
        ManageSingleton();
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "Menu")
        {
            myAudio.clip = menuSong;
        }
        else if(SceneManager.GetActiveScene().name == "CS1")
        {
            myAudio.clip = cutsceneSong;
        }
        else
        {
            myAudio.clip= gameSong;
        }

        if(!myAudio.isPlaying)
        {
            myAudio.Play();
        }
    }
}
