using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    public EnemyStatsPerameters stats;

    public float health;
    public bool isBomber;
    //nash edit
    private float totalHP;
    public Explosion explosion;
    public Explosion gibbedExplosion;

    private bool gibbed;
    public delegate void OnDeath();
    public static OnDeath onDeath;
    //deligate for when an enemy is killed

    void Start()
    {
        //stats.health = 0;
        health = 0;
        health = stats.health;
        totalHP = stats.health;
        gibbed = false;
    }
    public void TakeDamage(float damage)
    {
        if (totalHP + 1 < damage)
        {
            gibbed = true;
            gameObject.SetActive(false);
            return;
        }

        health -= damage;
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        if (isBomber && explosion != null && gibbed == true)
        {
            InstaGib();
        }

        //delegate call
        onDeath?.Invoke();
    }

    private void InstaGib()
    {
        gibbedExplosion.Explode();
        //print("GIBBED");
    }

    public void BombPlayer()
    {
        TakeDamage(health);
        explosion.Explode();
        //print("KILLED SELF");
    }
}
