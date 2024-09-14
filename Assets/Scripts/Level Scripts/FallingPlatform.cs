using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{

    [SerializeField] float fallDelay = 1f;
    [SerializeField] float respawnDelay = 2f;

    Rigidbody2D rb;
    Vector3 initialPos;

    void Start()
    {
        initialPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine("StartFall");
        }
    }

    private IEnumerator StartFall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSeconds(respawnDelay);
        Reset();
    }

    private void Reset()
    {
        rb.bodyType = RigidbodyType2D.Static;
        transform.position = initialPos;
    }

}
