using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "EnemyStats", menuName = "Stats/Enemy")]
public class EnemyStatsPerameters : ScriptableObject
{
    public string enemyName;
    public float health;
    public bool canMove;
    [Header("Gun Stats")]
    public float fireRate;
    public float damage;
    public float bulletVelocity;
    public float bullAccuracy;
}
