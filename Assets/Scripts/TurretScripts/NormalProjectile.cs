 
using UnityEngine;
using System.Collections;
 

 
public class NormalProjectile : BaseProjectile {
    Vector3 m_direction;
    bool m_fired;
    private float damageToPlayer;
   
    
    public float timer;
    public Transform target;
    public GameObject endingFX;
    public Explosion explosion;
    public bool explosiveRound;

    // Update is called once per frame
    void Update () {
        if(m_fired){
            //transform.position += m_direction * (speed * Time.deltaTime);
        }

        transform.LookAt(target);

         timer += 1.0F * Time.deltaTime;

        /*
         if (timer >= 4)
                {
                GameObject.Destroy(gameObject);
                }
        transform.LookAt(target);
        */
    }
 
    public override void FireProjectile(GameObject launcher, GameObject target, float damage, float attackSpeed){
        if(launcher && target){
            //m_direction = (target.transform.position - launcher.transform.position).normalized;
            m_fired = true;
            damageToPlayer = damage;
        }
    }
    private void OnBecameInvisible()
    {
        GameObject.Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                other.gameObject.GetComponentInParent<PlayerStats>().TakeDamage(damageToPlayer);
                Instantiate(endingFX, transform.position, transform.rotation);
                Destroy(gameObject);
                break;
            case "AutoTurret":
                Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), other.gameObject.GetComponent<Collider>(), true);
                break;
            case "PlayerBullet":
                Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), other.gameObject.GetComponent<Collider>(), true);
                break;
            case "Mine":
                Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), other.gameObject.GetComponent<Collider>(), true);
                break;
            case "Untagged":
                if(explosiveRound)
                {
                    if (explosion != null)
                    {
                        explosion.Explode();
                    }
                }
                Destroy(gameObject);
                break;
        }
    }


}
 