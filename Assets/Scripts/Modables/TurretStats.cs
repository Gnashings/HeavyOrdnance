using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "TurretMods", menuName = "ScriptableObjects/Turret")]
public class TurretStats : ScriptableObject
{
    public float fireRate;
    public float bulletVelocity;
    public float bulletSpread;
    public float damage;
    public bool dealDamage;
    public bool explosiveProjectile;
    public bool destroysOtherShots;
    public GameObject fireFX;
}
