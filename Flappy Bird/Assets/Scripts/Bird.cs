using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private GameManager GM;
    private UIManager UI;

    private Rigidbody2D rb;

    private Score score;

    public Sprite Flap;
    public Sprite NotFlap;

    [SerializeField] private float Speed;
    public float animationTime = 3;
    private float waitTime;

    public bool gameOver = false;
    Vector2 spawn;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        score = FindObjectOfType<Score>();
        GM = FindObjectOfType<GameManager>();
        UI = FindObjectOfType<UIManager>();
        spawn = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!UI.InMenu)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            if (!gameOver)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    GetComponent<SpriteRenderer>().sprite = Flap;
                    waitTime = Time.time + animationTime;
                    rb.velocity = new Vector2(rb.velocity.x, Speed);
                }
                    Debug.Log(Time.time > animationTime);
                if (Time.time > waitTime)
                {
                     GetComponent<SpriteRenderer>().sprite = NotFlap;
                }
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GM.Pause();
            }
        }
        if (UI.InMenu)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
    public void GameOver()
    {
        rb.velocity = Vector2.zero;
        gameOver = true;
        GM.GameOver();
        Debug.Log("Game Over");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tube")
        {
            GameOver();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            Debug.Log("Score + 1");
            score.ScoreUpdate(1);
        }
    }
    public void ResetBird()
    {
        transform.position = spawn;
        gameOver = false;
    }
}
