using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    public List<GameObject> enemies = new List<GameObject>();
    private GameObject trackKill;
    private int currentEnemyIndex;
    private ParticleSystem spawnEffect;
    //TODO TRACK THE DEATH OF EACH ENEMY SPAWNED
    void Start()
    {
        if (enemy == null)
        {
            Debug.LogError("NO ENEMY ASSIGNED");
        }
        spawnEffect = gameObject.GetComponent<ParticleSystem>();
    }

    void Update()
    {

    }

    public void TriggerDoor()
    {
        enemy.SetActive(true);
    }

    public void HideDoor()
    {
        enemy.SetActive(false);
    }

    public bool TriggerEnemy()
    {
        //Instantiate(enemy, transform.position, Quaternion.identity, gameObject.transform);
        if (currentEnemyIndex + 1 > enemies.Count)
        {
            return false;
        }
        else
        {
            spawnEffect.Play();
            Instantiate(enemies[currentEnemyIndex], transform.position, Quaternion.identity, gameObject.transform);
            currentEnemyIndex++;
        }
        return true;

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 2f);
    }
}
