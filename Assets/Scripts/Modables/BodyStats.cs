using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TankMods", menuName = "ScriptableObjects/Body")]
public class BodyStats : ScriptableObject
{
    public float armor;
    public float health;
    public float topSpeed;
    public float armorRecharge;
    public float armorBreakTimer;
}
