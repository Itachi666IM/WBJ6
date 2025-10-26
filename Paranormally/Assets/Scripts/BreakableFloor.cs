using System.Collections;
using UnityEngine;

public class BreakableFloor : MonoBehaviour
{
    [SerializeField] float destructionTime;
    [SerializeField] GameObject breakableFloorSil;
    SFXManager sFXManager;
    [SerializeField] AudioClip breakSound;
    GhostMode ghostMode;
    private void Awake()
    {
        ghostMode = FindAnyObjectByType<GhostMode>();
        sFXManager = FindAnyObjectByType<SFXManager>();
    }

    private void Update()
    {
        if(ghostMode.isGhostModeOn)
        {
            breakableFloorSil.SetActive(true);
        }
        else
        {
            breakableFloorSil.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(DestroyFloor());
        }
    }

    IEnumerator DestroyFloor()
    {
        sFXManager.PlayAnyAudio(breakSound);
        yield return new WaitForSeconds(destructionTime);
        Destroy(breakableFloorSil);
        Destroy(gameObject);
    }
}
