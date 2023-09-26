using UnityEngine;
using System.Collections;
 
public abstract class BaseProjectile : MonoBehaviour {
    [Tooltip("Set bullet speed")]
    public float speed;

    [Tooltip("Set bullet damage")]
    public float damage;


    
    public abstract void FireProjectile(GameObject launcher, GameObject target, float damage, float attackSpeed);
}
 