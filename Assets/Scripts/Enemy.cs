using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    public int health;
    public int dmg;

    [Header("Enemy FSM")]
    public Transform target;

    [Header("Idle Settings")]
    public EnemyStates state = EnemyStates.Idle;
    public Vector3 StartingPosition;

    [Header("Idle Settings")]
    public int huntTime = 5;
    float endHuntTime = 0f;

    [Header("Attack Settings")]
    public float attackDistance = 2f;
    public float attackCooldown = 1.12f;
    float nextAttackTime;
    public CapsuleCollider dmgColldier;

    [Header("Sight Settings")]
    public bool canSeePlayer;
    public Transform eyes;
    public int sightRange;
    public LayerMask sightBlockers;


    [Header("Components")]
    public NavMeshAgent navAgent;
    public Animator animator;


    void Start()
    {
        health = 10;
        navAgent = this.GetComponent<NavMeshAgent>();
        animator = this.GetComponent<Animator>();

        target = GameObject.FindGameObjectWithTag("Player").transform;
        StartingPosition = this.transform.position;
    }


    void Update()
    {
        canSeePlayer = CheckForPlayer();
        HandleStates();
        HandleAnimation();
    }

    bool CheckForPlayer()
    {
        //Check if the target is close enough to be seen.
        float distanceToTarget = Vector3.Distance(this.transform.position, target.position);

        if (distanceToTarget > sightRange)
            return false;

        //Now check for obstructions
        if (Physics.Linecast(eyes.position, target.position, sightBlockers))
            return false;
        //Target in range and not obstructed.
        return true;
    }

    void HandleAnimation()
    {
        float speedNorm = navAgent.velocity.magnitude / navAgent.speed;
        animator.SetFloat("Speed", speedNorm);

        float distanceToTarget = Vector3.Distance(this.transform.position, target.position);
        if (distanceToTarget <= attackDistance)
        {
            animator.SetTrigger("Attack");
        }
    }

    void HandleStates()
    {
        switch (state)
        {
            case EnemyStates.Idle:
                if (canSeePlayer)
                    state = EnemyStates.Chasing;
                break;

            case EnemyStates.Chasing:
                navAgent.destination = target.position;
                if (!canSeePlayer)
                {
                    state = EnemyStates.Hunting;
                    endHuntTime = Time.time + huntTime;
                }
                break;
            case EnemyStates.Attack:
                this.transform.LookAt(target);
                break;
            case EnemyStates.Hunting:
                if (canSeePlayer)
                {
                    state = EnemyStates.Chasing;
                }
                else if (Time.time > endHuntTime)
                {
                    state = EnemyStates.Idle;
                    navAgent.destination = StartingPosition;
                }
                break;
        }
    }

    public void TakeDamage(int takeDmg)
    {
        Debug.Log("Enemy Took Damage " + takeDmg);

        health -= takeDmg;

        if (health <= 0)
            Destroy(this.gameObject);
    }

    //Unity animation was being a pain, wasnt letting me enabled the collider in the animation i dont know why
    //so i made this abomination.
    public void EnableDmgCollider()
    {
        dmgColldier.enabled = true;
    }
    public void DisableDmgCollider()
    {
        dmgColldier.enabled = false;
    }

}

public enum EnemyStates
{
    Idle,
    Chasing,
    Attack,
    Hunting
}

