using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public GameObject powerUpPrefab;
    public float respawnTime = 5f;

    private Vector3 initialPosition;
    private GameObject currentPowerUp;

    private void Start()
    {
        initialPosition = transform.position; // Store the initial position
        SpawnPowerUp();
    }

    void SpawnPowerUp()
    {
        currentPowerUp = Instantiate(powerUpPrefab, initialPosition, Quaternion.identity);
    }

    public void RespawnPowerUp()
    {
        StartCoroutine(RespawnRoutine());
    }

    IEnumerator RespawnRoutine()
    {
        yield return new WaitForSeconds(respawnTime);
        if (currentPowerUp != null)
            Destroy(currentPowerUp);

        SpawnPowerUp();
    }
}