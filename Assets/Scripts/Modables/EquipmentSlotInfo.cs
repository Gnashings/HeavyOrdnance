using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EquipmentInfo", menuName = "ScriptableObjects/EquipmentInfo")]
public class EquipmentSlotInfo : ScriptableObject
{
    public string identifier;
    public string title;
    public string description;
    public string specialEffect;
    public float cost;

    public TurretStats turretStats;
    public BodyStats bodyStats;
    public TrackStats trackStats;

    public PartType partType;
    [System.Serializable]
    public enum PartType
    {
        AddOn,
        Turret,
        Armor,
        Track
    };
}
