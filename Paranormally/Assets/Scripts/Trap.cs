using UnityEngine;
using UnityEngine.SceneManagement;
public class Trap : MonoBehaviour
{
    TrapSpawner spawner;
    Rigidbody2D rb;
    [SerializeField] int speed;
    GhostMode ghostMode;
    private void Awake()
    {
        ghostMode = FindAnyObjectByType<GhostMode>();
        spawner = FindAnyObjectByType<TrapSpawner>();   
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        Destroy(gameObject, 4f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !ghostMode.isGhostModeOn)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void Update()
    {
        if (spawner.isGoingLeft)
        {
            rb.position = Vector2.MoveTowards(rb.position, Vector2.left*100, speed * Time.deltaTime);
        }
        else if (spawner.isGoingRight)
        {
            rb.position = Vector2.MoveTowards(rb.position, Vector2.right*100, speed * Time.deltaTime);
        }
        else if (spawner.isGoingDown)
        {
            rb.position = Vector2.MoveTowards(rb.position, Vector2.down*100, speed * Time.deltaTime);
        }
        else if (spawner.isGoingUp)
        {
            rb.position = Vector2.MoveTowards(rb.position, Vector2.up * 100, speed * Time.deltaTime);
        }
    }
}
