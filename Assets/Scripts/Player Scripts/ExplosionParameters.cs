using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Explosions", menuName = "ScriptableObjects/Explosions")]
public class ExplosionParameters : ScriptableObject
{
    [Tooltip("the size the explosion")]
    public float radius;
    [Tooltip("the amount of impact force in the explosion at the point of contact")]
    public float force;
    [Tooltip("the amount of damage dealt in the explosion")]
    public float damage;
    [Tooltip("the amount of upward force in the explosion")]
    public float upwardforce;

    [Tooltip("the particles")]
    public GameObject particles;

    [Header("Player Interactions")]
    public bool canDamagePlayer;
    public bool canAffectPlayer;

    [Header("Enemy Interactions")]
    public bool canDamageEnemies;
    public bool canAffectEnemies;
}
