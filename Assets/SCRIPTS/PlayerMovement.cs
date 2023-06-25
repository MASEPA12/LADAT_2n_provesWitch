using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 16f ;
    public Rigidbody2D rb2d;

    //points system easy basic
    public int points = 0;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if(points == 8)
        {
            Debug.Log("YOU HAVE RECOLLECTED ALL THE SLIMES");
            Time.timeScale = 0;
        }
    }
    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(horizontalInput * speed, verticalInput * speed);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("slime"))
        {
            Destroy(other.gameObject);
            points++;
            Debug.Log($"{points}");
        }
    }
}
