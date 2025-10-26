using UnityEngine;
public class TrapSpawner : MonoBehaviour
{
    [SerializeField] GameObject trapPrefab;
    [SerializeField] GameObject trapSilPrefab;

    public bool isGoingRight;
    public bool isGoingLeft;
    public bool isGoingUp;
    public bool isGoingDown;

    public float timeBetweenSpaens;
    float nextSpawnTime;
    GhostMode ghostMode;
    private void Awake()
    {
        ghostMode = FindAnyObjectByType<GhostMode>();
    }

    void Left()
    {
        if(ghostMode.isGhostModeOn)
        {
            Instantiate(trapSilPrefab, transform.position,Quaternion.Euler(0,0,0));
        }
        else
        {
            Instantiate(trapPrefab, transform.position, Quaternion.Euler(0, 0,0));
        }
    }

    void Right()
    {
        if (ghostMode.isGhostModeOn)
        {
            Instantiate(trapSilPrefab, transform.position, Quaternion.Euler(0, 0, 180));
        }
        else
        {
            Instantiate(trapPrefab, transform.position, Quaternion.Euler(0, 0, 180));
        }
    }

    void Up()
    {
        if (ghostMode.isGhostModeOn)
        {
            Instantiate(trapSilPrefab, transform.position, Quaternion.Euler(0, 0, 270));
        }
        else
        {
            Instantiate(trapPrefab, transform.position, Quaternion.Euler(0, 0, 270));
        }
    }

    void Down()
    {
        if (ghostMode.isGhostModeOn)
        {
            Instantiate(trapSilPrefab, transform.position, Quaternion.Euler(0, 0, 90));
        }
        else
        {
            Instantiate(trapPrefab, transform.position, Quaternion.Euler(0, 0, 90));
        }
    }

    private void Update()
    {
        if(Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + timeBetweenSpaens;
            if (isGoingLeft)
            {
                Left();
            }
            if (isGoingRight)
            {
                Right();
            }
            if (isGoingUp)
            {
                Up();
            }
            if (isGoingDown)
            {
                Down();
            }
        }
    }
}
