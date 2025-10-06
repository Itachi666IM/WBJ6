using UnityEngine;

public class Sound : MonoBehaviour
{
    AudioSource myAudio;
    [SerializeField] AudioClip hoverSound;
    [SerializeField] AudioClip clickSound;

    private void Awake()
    {
        myAudio = GetComponent<AudioSource>();
        myAudio.volume = FindAnyObjectByType<SFXManager>().volume;
    }

    public void HoverSound()
    {
        myAudio.PlayOneShot(hoverSound);
    }

    public void ClickSound()
    {
        myAudio.PlayOneShot(clickSound);
    }

}
