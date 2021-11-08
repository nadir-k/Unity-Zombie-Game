using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    /*public enum EnemyState
    {
        Idle = 0,
        Patrolling,
        Chasing,
        Attack
    }*/
    //public EnemyState state;
    //private int speedHashId;
    //public float distanceToStartChasingTarget = 15.0f;
    //public float timePursuingTarget = 10;

    Transform target;
    NavMeshAgent enemy;
    Animator anim;

    public Collider col;
    public Transform[] waypoints;
    private int waypointId = 0;
    public float distanceToNextWaypoint = 1;

    public float lookRadius = 10f;
    public float speed = 2f;

    bool isDead = false;
    public bool canAttack = true;
    public float dmgAmount = 1f;
    [SerializeField]
    float attackTime = 0.93f;

    void Awake() {
        GameObject player = GameObject.Find("Player");
        col = GetComponent<Collider>();
        target = player.transform;
        enemy = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        enemy.speed = 1f;

        if (waypoints.Length == 0)
        {
            Debug.LogError("Error: list of waypoints is empty.");
            GameObject.Destroy(gameObject);
            return;
        }
    }

    void FixedUpdate() {

        if (canAttack)
        {
            if (!isDead)
            {
                if (enemy.remainingDistance < distanceToNextWaypoint)
                {
                    enemy.isStopped = false;
                    enemy.stoppingDistance = 0;
                    anim.SetBool("isWalking", true);
                    anim.SetBool("isChasing", false);

                    waypointId = (waypointId + 1) % waypoints.Length;
                    enemy.SetDestination(waypoints[waypointId].position);

                } 

                float distance = Vector3.Distance(target.position, transform.position);

                if (distance <= lookRadius)
                {
                    ChasePlayer();
                    canAttack = true;

                    if (distance <= enemy.stoppingDistance || distance < 1.2f)
                    {
                        AttackPlayer();
                    }
                } 

            } else {
                enemy.updatePosition = false;
                enemy.speed = 0f;
                anim.SetBool("isWalking", false);
                anim.SetBool("isChasing", false);
                enemy.isStopped = true;
            }
        } else
        {
            return;
        }
    }

    void FaceTarget() {
        Vector3 planarDifference = (target.position - transform.position);
        planarDifference.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(planarDifference.normalized);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
    }

    public void EnemyDieAnim() {
        isDead = true;
        anim.SetTrigger("isDead");
        col.enabled = false;
        
    }

    void ChasePlayer()
    {
        enemy.speed = 2f;
        enemy.updatePosition = true;
        enemy.SetDestination(target.position);
        anim.SetBool("isWalking", false);
        anim.SetBool("isChasing", true);
    }

    void AttackPlayer() {

        FaceTarget();
        if (canAttack)
        {
            enemy.updatePosition = false;
            anim.SetBool("isWalking", false);
            anim.SetBool("isChasing", false);
            anim.SetTrigger("Attack");
            StartCoroutine(AttackTime());
        }

    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Player")
        {
            AttackTime();
        }
    }

    IEnumerator AttackTime()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackTime);
        Player.single.DamagePlayer(dmgAmount);
        canAttack = true;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    bool GetIsDead() {
        return isDead;
    }
}
