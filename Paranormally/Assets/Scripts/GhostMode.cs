using UnityEngine;
using UnityEngine.InputSystem;

public class GhostMode : MonoBehaviour
{
    public GameObject[] coloredObjects;
    public GameObject[] silhouetteObjects;
    bool isColored = true;
    [HideInInspector]public bool canUseGhostMode = false;
    [HideInInspector]public bool isGhostModeOn = false;
    public GameObject player;
    public GameObject silhouette;
    SFXManager sfxManager;
    [SerializeField] AudioClip ghostSound;
    private void Awake()
    {
        sfxManager = FindAnyObjectByType<SFXManager>();
    }
    void ToggleGameObjects()
    {
        if(isColored)
        {
            isGhostModeOn=true;
            isColored = false;
            for (int i = 0; i < silhouetteObjects.Length; i++)
            {
                silhouetteObjects[i].SetActive(true);
            }
            for (int i = 0; i < coloredObjects.Length; i++)
            {
                coloredObjects[i].SetActive(false);
            }
            silhouette.transform.position = player.transform.position;
        }
        else
        {
            isGhostModeOn = false;
            isColored = true;
            for (int i = 0; i < coloredObjects.Length; i++)
            {
                coloredObjects[i].SetActive(true);
            }
            for (int i = 0; i < silhouetteObjects.Length; i++)
            {
                silhouetteObjects[i].SetActive(false);
            }
            player.transform.position = silhouette.transform.position;
        }
    }

    private void Update()
    {
        if(canUseGhostMode && Keyboard.current.xKey.wasPressedThisFrame)
        {
            sfxManager.PlayAnyAudio(ghostSound);
            ToggleGameObjects();
        }
    }
}
