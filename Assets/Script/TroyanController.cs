using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TroyanController : MonoBehaviour
{
    [SerializeField] Transform player, homePosition, patrolCenter;
    [SerializeField] GameObject sword, bubble, particles;
    [SerializeField] float attackRange = 1.5f, patrolRadius = 15.0f;
    [SerializeField] float attackCooldown = 5.0f, HP = 6.0f, smallBulletResistance = 4f, bigBulletResistance = 0.3f;
    [SerializeField] bool canMove = true;

    float lastAttack = 0f;
    UnityEngine.AI.NavMeshAgent agent;
    Animator animator;
    EnemyState actualState;
    bool goHomeBro = false, canAttackPlayer = false;

    enum EnemyState
    {
        Idle,
        Moving,
        Attacking,
        Death
    };
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();
        actualState = EnemyState.Idle;
        bubble.gameObject.SetActive(false);
    }

    void Update()
    {
        //Debug.Log(HP);
        float patrolDistance = Vector3.Distance(patrolCenter.position, transform.position);
        if (actualState!=EnemyState.Death)
        {
        switch (actualState)
        {
            case EnemyState.Idle:
                animator.Play("Idle");
            break;

            case EnemyState.Moving:
                animator.Play("Moving");
            break;

            case EnemyState.Attacking:
                animator.Play("Attack");
                sword.GetComponent<BoxCollider>().enabled = true;
            break;

        }
        if (patrolDistance > patrolRadius)
        {
            goHomeBro = true;
        }
        {
        //Debug.Log("home: " + goHomeBro + " - " + "canAttack: " + canAttackPlayer);
        if (canMove && Time.time >= lastAttack + attackCooldown)
        {
        if (goHomeBro)
        {
        agent.SetDestination(homePosition.transform.position);
            if (patrolDistance < patrolRadius/4)
            {
                goHomeBro=false;
                canAttackPlayer=false;
            }
        }
        else
        {
        if (canAttackPlayer)
        {
        agent.SetDestination(player.transform.position);
        }
        }
        actualState = EnemyState.Moving;
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= attackRange)
        {
            AttackPlayer();
        }
        }
        }
        }
    }

    void AttackPlayer()
    {
        actualState = EnemyState.Attacking;
        lastAttack = Time.time;
        //logica para sacarle la faka al player
        StartCoroutine(ResetState());
    }

    IEnumerator ResetState()
    {
        yield return new WaitForSeconds(1.5f);
        sword.GetComponent<BoxCollider>().enabled = false;
        actualState = EnemyState.Idle;
    }

    IEnumerator wait2secs()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    public void TriggerAttack(bool canAttack, bool home)
    {
        if (canAttack)
        {
            canAttackPlayer = true;
        }
        if (home)
        {
            goHomeBro = false;
        }
    }

    public void getDamage(float damage)
    {
        HP-=damage;
        if (HP <= 0)
        {
            actualState = EnemyState.Death;
            bubble.gameObject.SetActive(true);
            animator.Play("Dead");
            StartCoroutine(wait2secs());
            
        }
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Bullet")
        {
            float bulletDamage = other.transform.localScale.x;
            if (other.transform.localScale.x <= 1f)
            {
                bulletDamage /= smallBulletResistance;
            }
            else
            {
                bulletDamage -= bigBulletResistance;
            }
            getDamage(bulletDamage);
            other.gameObject.GetComponent<LifeBubble>().destroyBubble();
        }
    }

}
