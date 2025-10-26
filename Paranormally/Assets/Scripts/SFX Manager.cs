using UnityEngine;
using UnityEngine.UI;

public class SFXManager : MonoBehaviour
{
    public float volume;
    [SerializeField] Slider volumeSlider;
    AudioSource audioSource;
    void ManageSingleton()
    {
        int instance = FindObjectsByType<SFXManager>(FindObjectsSortMode.None).Length;
        if(instance>1)
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
        audioSource = GetComponent<AudioSource>();
        ManageSingleton();
    }

    public void UpdateSFXVolume()
    {
        volume = volumeSlider.value;
        audioSource.volume = volume;
    }

    public void PlayAnyAudio(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
