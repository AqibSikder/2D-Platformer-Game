//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class RangedEnemy : MonoBehaviour
//{

//    [Header("Attack Parameters")]
//    [SerializeField] private float attackCooldown;
//    [SerializeField] private float range;
//    [SerializeField] private int damage;

//    [Header("Collider Parameters")]
//    [SerializeField] private float colliderDistance;
//    [SerializeField] private BoxCollider2D boxCollider;

//    [Header("Player Layer")]
//    [SerializeField] private LayerMask playerLayer;
//    private float cooldownTimer = Mathf.Infinity;

//    [Header("Ranged Attack")]
//    [SerializeField] private Transform pelletPoint;
//    [SerializeField] private GameObject[] pellets;

//    void Awake()
//    {
//    }
//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        cooldownTimer += Time.deltaTime;

//        if (PlayerInSight())
//        {
//            if (cooldownTimer >= attackCooldown)
//            {
//                cooldownTimer = 0;
//            }
//        }
//    }

//    private void RangedAttack()
//    {
//        cooldownTimerTimer = 0;
//        pellets[FindPellet()].transform.position = pelletPoint.position;
//        pellets[FindPellet()].GetComponent<EnemyProjectile>().ActivateProjectile();
//    }

//    private int FindPellet()
//    {
//        for (int i=0; i < pellets.Length; i++)
//        {
//            if (!pellets[i].activeInHierarchy)
//            {
//                return i;
//            }
//        }
//    }
//    private bool PlayerInSight()
//    {
//        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
//            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);

//        return hit.collider != null;
//    }

//    private void OnDrawGizmos()
//    {
//        Gizmos.color = Color.red;
//        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
//            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
//    }

//}
