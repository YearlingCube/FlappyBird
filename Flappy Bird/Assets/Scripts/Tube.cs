using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tube : MonoBehaviour
{
    public Transform TubeSpawn;
    public Bird bird;
    public float move;
    Vector2 spawn;
    private UIManager UI;
    // Start is called before the first frame update
    void Start()
    {
        spawn = transform.position;
        move = -move;
        bird = FindObjectOfType<Bird>();
        UI = FindObjectOfType<UIManager>();
        transform.position = new Vector2(transform.position.x, Random.Range(-10.89f, -4.52f));

    }

    // Update is called once per frame
    void Update()
    {
        if (!UI.InMenu)
        {
            if (!bird.gameOver)
            {
            transform.position = new Vector2(transform.position.x + move * Time.deltaTime, transform.position.y);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
            Debug.Log("Reset");
        if (collision.gameObject.tag == "TubeReset")
        {
            transform.position = new Vector2(TubeSpawn.position.x, Random.Range(-10.89f, -4.52f));
        }
    }
    public void ResetTube()
    {
        transform.position = spawn;
    }
}
