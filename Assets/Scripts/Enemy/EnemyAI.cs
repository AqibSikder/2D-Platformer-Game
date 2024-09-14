using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public Vector2 minBoundary;
    public Vector2 maxBoundary;

    public bool isActive = false;

    EnemyHealth enemyHealth;

    public Transform player;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject portalObject;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
        enemyHealth = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {

        if (IsWithinBoundary(player.position) && !isActive)
        {
            isActive = true;
        }

        else if (!IsWithinBoundary(player.position) && isActive)
        {
            isActive = false;
        }

        if (isActive)
        {
            if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance
                (transform.position, player.position) > retreatDistance)
            {
                transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }

            if (timeBtwShots <= 0)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }

    }

    bool IsWithinBoundary(Vector2 position)
    {
        return position.x >= minBoundary.x && position.x <= maxBoundary.x &&
               position.y >= minBoundary.y && position.y <= maxBoundary.y;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pellet"))
        {
            enemyHealth.TakeDamage(10);
        }
    }
}
