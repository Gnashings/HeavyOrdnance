using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RammingModule : MonoBehaviour
{
    public Rigidbody rb;

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Enemy") && rb.velocity.magnitude >= 60f)
        {
            other.collider.GetComponent<EnemyStats>().TakeDamage(100);
        }

    }
}
