using System.Collections;
using UnityEngine;

public class BreakableFloor : MonoBehaviour
{
    [SerializeField] float destructionTime;
    [SerializeField] GameObject breakableFloorSil;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(DestroyFloor());
        }
    }

    IEnumerator DestroyFloor()
    {
        //play breaking sfx
        yield return new WaitForSeconds(destructionTime);
        Destroy(breakableFloorSil);
        Destroy(gameObject);
    }
}
