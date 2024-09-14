using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform pelletPoint;
    [SerializeField] private GameObject[] pellets;
    private PlayerController playerController;
    private float cooldownTimer =  Mathf.Infinity;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown)
        {
            Attack();
        }

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        cooldownTimer = 0;
        pellets[FindPellet()].transform.position = pelletPoint.position;
        pellets[FindPellet()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));

    }

    private int FindPellet()
    {
        for (int i = 0; i < pellets.Length; i++)
        {
            if (!pellets[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}
