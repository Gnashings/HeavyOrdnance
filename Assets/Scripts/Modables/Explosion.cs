using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles when things go boom
/// </summary>
public class Explosion : MonoBehaviour
{
    public ExplosionParameters explosion;

    public void Explode()
    {   
        ParticleSystem fx;
        if(explosion.particles != null)
        {
            //parent
            float r = explosion.radius;
            ParticleSystem.ShapeModule ps = explosion.particles.GetComponent<ParticleSystem>().shape;
            ps.radius = r;
            
            //child
            float rc = explosion.radius;
            ParticleSystem.ShapeModule psc = explosion.particles.transform.GetChild(0).GetComponent<ParticleSystem>().shape;
            psc.radius = rc*0.25f;
            Instantiate(explosion.particles, transform.position, transform.rotation);
        }
        
        Physics.OverlapSphere(transform.position, explosion.radius);
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosion.radius);

        foreach (Collider hitObj in colliders)
        {
            Rigidbody rb = hitObj.transform.GetComponentInParent<Rigidbody>();
            if (rb != null)
            {
                DoPhysics(hitObj, rb);
            }
            DamageTargets(hitObj);
        }
    }

    private void DoPhysics(Collider other, Rigidbody rb)
    {
        if (explosion.canAffectPlayer && other.CompareTag("Player"))
        {
            rb.AddExplosionForce(explosion.force, other.ClosestPointOnBounds(gameObject.transform.position), explosion.radius, explosion.upwardforce, ForceMode.VelocityChange);
        }
        if (explosion.canAffectEnemies && other.CompareTag("Enemy"))
        {
            rb.AddExplosionForce(explosion.force, other.ClosestPointOnBounds(gameObject.transform.position), explosion.radius, explosion.upwardforce, ForceMode.Impulse);
        }
        else
        {
            if (other.tag.Equals("Mine"))
            {
                rb.AddExplosionForce(25 , other.ClosestPoint(gameObject.transform.position), 10, 2, ForceMode.VelocityChange);
            }
        }
    }

    private void DamageTargets(Collider other)
    {
        if(explosion.canDamageEnemies && other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyStats>().TakeDamage(explosion.damage * (1 + PlayerProgress.roidDmgMod));
        }
        if(explosion.canDamagePlayer && other.CompareTag("Player"))
        {
            other.gameObject.GetComponentInParent<PlayerStats>().TakeDamage(explosion.damage);     
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, explosion.radius);
    }
}
