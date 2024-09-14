using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Vector2 direction = CalculateSnowDirection(); // Determine the direction of the snow effect
            float forceMagnitude = CalculateSnowForce(); // Determine the force strength

            Rigidbody2D playerRB = other.GetComponent<Rigidbody2D>();
            playerRB.AddForce(direction * forceMagnitude, ForceMode2D.Force);
        }
    }

    Vector2 CalculateSnowDirection()
    {
        return Vector2.right;
    }

    float CalculateSnowForce()
    {

        return 1000f; 
    }

}
