using UnityEngine;
using UnityEngine.InputSystem;

public class GhostMode : MonoBehaviour
{
    public GameObject[] coloredObjects;
    public GameObject[] silhouetteObjects;
    bool isColored = true;
    [HideInInspector]public bool canUseGhostMode = false;
    void ToggleGameObjects()
    {
        if(isColored)
        {
            isColored = false;
            for (int i = 0; i < silhouetteObjects.Length; i++)
            {
                silhouetteObjects[i].SetActive(true);
            }
            for (int i = 0; i < coloredObjects.Length; i++)
            {
                coloredObjects[i].SetActive(false);
            }
        }
        else
        {
            isColored = true;
            for (int i = 0; i < coloredObjects.Length; i++)
            {
                coloredObjects[i].SetActive(true);
            }
            for (int i = 0; i < silhouetteObjects.Length; i++)
            {
                silhouetteObjects[i].SetActive(false);
            }
        }
    }

    private void Update()
    {
        if(canUseGhostMode && Keyboard.current.xKey.wasPressedThisFrame)
        {
            ToggleGameObjects();
        }
    }
}
