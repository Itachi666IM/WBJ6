using UnityEngine;
using UnityEngine.UI;

public class SFXManager : MonoBehaviour
{
    public float volume;
    [SerializeField] Slider volumeSlider;
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
        ManageSingleton();
    }

    public void UpdateSFXVolume()
    {
        volume = volumeSlider.value;
    }
}
