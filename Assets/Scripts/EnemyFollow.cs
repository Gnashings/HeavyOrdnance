using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public EnemyStats enemyStats;
    public NavMeshAgent enemyNavMesh;

    private float explosionTimer = 0.25f;
    private Transform player;
    public Rigidbody rb;
    private bool isClose = false;
    // Start is called before the first frame update
    void Start()
    {
          if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;
        
        //Debug.Log("REMAINING:" + enemy.remainingDistance + " STOPPING:" + enemy.stoppingDistance);
    }
    

    void FixedUpdate()
    {
        CanMove();
    }

    private void LateUpdate()
    {
        if(enemyStats.stats.canMove)
        {

            if(enemyNavMesh.remainingDistance > 1f)
            {
                if (enemyNavMesh.remainingDistance < enemyNavMesh.stoppingDistance && isClose == false)
                {
                    isClose = true;
                    StartCoroutine(TimedExplosion());
                    //print("dis " + enemyNavMesh.remainingDistance + " st " + enemyNavMesh.stoppingDistance);
                }
                else
                {
                    isClose = false;
                }
            }

        }

    }
    void CanMove()
    {
        if(enemyStats.stats.canMove)
        {
            enemyNavMesh.SetDestination(player.position);
        }
    }

    IEnumerator TimedExplosion()
    {
        yield return new WaitForSeconds(explosionTimer);
        if (enemyNavMesh.remainingDistance < enemyNavMesh.stoppingDistance && isClose == true)
        {
            if (enemyStats.isBomber)
            {
                enemyStats.BombPlayer();
            }
        }
        else
        {
            isClose = false;
        }
    }
}
