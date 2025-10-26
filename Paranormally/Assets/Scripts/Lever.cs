using UnityEngine;
using UnityEngine.InputSystem;

public class Lever : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite leverClose;
    [SerializeField] Sprite leverOpen;
    [SerializeField] Sprite leverCloseSil;
    [SerializeField] Sprite leverOpenSil;
    bool isLeverOpen = false;

    GhostMode ghostMode;
    bool canPullLever = false;

    public GameObject wallTrap;
    public GameObject wallTrapSil;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ghostMode = FindAnyObjectByType<GhostMode>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !ghostMode.isGhostModeOn)
        {
            canPullLever = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            canPullLever = false;
        }
    }

    private void Update()
    {

        ChangeSprites();
        SwitchWallTrap();

        if(canPullLever && Keyboard.current.eKey.wasPressedThisFrame)
        {
            if(isLeverOpen)
            {
                isLeverOpen = false;
            }
            else if(!isLeverOpen)
            {
                isLeverOpen = true;
            }
        }
    }

    void SwitchWallTrap()
    {
        if(ghostMode.isGhostModeOn)
        {
            if(isLeverOpen)
            {
                wallTrap.SetActive(false);
                wallTrapSil.SetActive(false);
            }
            else
            {
                wallTrap.SetActive(false);
                wallTrapSil.SetActive(true);
            }
        }
        else
        {
            if(isLeverOpen)
            {
                wallTrap.SetActive(false);
                wallTrapSil.SetActive(false);
            }
            else
            {
                wallTrapSil.SetActive(false);
                wallTrap.SetActive(true);
            }
        }
    }

    void ChangeSprites()
    {
        if (ghostMode.isGhostModeOn)
        {
            if (isLeverOpen)
            {
                spriteRenderer.sprite = leverOpenSil;
            }
            else
            {
                spriteRenderer.sprite = leverCloseSil;
            }
        }
        else
        {
            if (isLeverOpen)
            {
                spriteRenderer.sprite = leverOpen;
            }
            else
            {
                spriteRenderer.sprite = leverClose;
            }
        }
    }
}
