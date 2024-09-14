using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPatrol : MonoBehaviour
{

    public float speed;
    public float distance;
    private bool movingRight = true;
    Vector3 initialPos;

    GameController gameController;

    public Transform groundDetection;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("Player").GetComponent<GameController>();
    }
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pellet")) 
        {
            // Destroy the AI when hit by a pellet
            Destroy(gameObject);
        }

        if (other.CompareTag("Player")) 
        {
            Vector2 contactPoint = other.ClosestPoint(transform.position);

            // Check if the player collided from above
            if (contactPoint.y > transform.position.y)
            {
                // Destroy the AI when hit by the player from above
                Destroy(gameObject);
            }
            else
            {
                // Kill the player
                gameController.Die();
            }
        }
    }

    private void Reset()
    {
        transform.position = initialPos;
    }
}
