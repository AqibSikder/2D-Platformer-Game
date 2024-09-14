using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float respawnTime = 5f; // Time in seconds before the power-up respawns
    private Collider2D collider;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        collider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Assign the SpriteRenderer component
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.AddExtraJump();
                StartCoroutine(RespawnPowerUp(respawnTime));
            }
        }
    }

    private IEnumerator RespawnPowerUp(float time)
    {
        collider.enabled = false; // Disable the collider
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(time); // Wait for the specified duration
        collider.enabled = true; // Enable the collider to make it triggerable again
        spriteRenderer.enabled = true;
    }
}