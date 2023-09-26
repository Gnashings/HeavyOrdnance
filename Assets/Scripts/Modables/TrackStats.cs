using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "TrackMods", menuName = "ScriptableObjects/Track")]
public class TrackStats : ScriptableObject
{
    [Tooltip("Turning this on makes the tank always move at top speed.")]
    public bool ignoreAcceleration;
    [Tooltip("Slows cut down your acceleration and top speed.")]
    public bool ignoreSlow;
    [Tooltip("I highly recommend 5 being the average acceleration.")]
    public float acceleration;
    [Tooltip("I highly recommend 2 being the average turning speed.")]
    public float turningSpeed;
}
