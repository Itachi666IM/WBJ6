using UnityEngine;

public class Sound : MonoBehaviour
{
    AudioSource myAudio;
    [SerializeField] AudioClip hoverSound;
    [SerializeField] AudioClip clickSound;

    private void Awake()
    {
        myAudio = GetComponent<AudioSource>();
        SFXManager sfxManager = FindAnyObjectByType<SFXManager>();
        if(sfxManager != null )
        {
            myAudio.volume = sfxManager.volume;
        }
        else
        {
            myAudio.volume = 0.5f;
        }
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
