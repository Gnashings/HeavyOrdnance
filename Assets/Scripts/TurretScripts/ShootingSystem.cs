using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
public class ShootingSystem : MonoBehaviour {
    private float fireRate;
    private float damage;
    public float fieldOfView;
    public GameObject projectile;
    public List<GameObject> projectileSpawns;
    public EnemyStatsPerameters perams;
    
 
    List<GameObject> lastProjectilesShot = new List<GameObject>();
    float m_fireTimer = 0.0f;
    private GameObject target;
    private float shotVelocity;
    private float accuracy;

    void Start()
    {
        fireRate = 0f;
        damage = 0f;
        fireRate = perams.fireRate;
        damage = perams.damage;
        shotVelocity = perams.bulletVelocity;
        accuracy = perams.bullAccuracy;
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player");

        
    }


    // Update is called once per frame
    void Update () {
        if(!target)
        {
            
 
            return;
        }

            m_fireTimer += Time.deltaTime;
 
            if(m_fireTimer >= fireRate){
                float angle = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position));
             
                if(angle < fieldOfView){
                    SpawnProjectiles();
                 
                    m_fireTimer = 0.0f;
                }
            }
     
    }
 
    void SpawnProjectiles(){
        if(!projectile){
            return;
        }
 
        lastProjectilesShot.Clear();
 
        for(int i = 0; i < projectileSpawns.Count; i++){
            if(projectileSpawns[i]){
                Quaternion firingDirection = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(90, 0, 0));
                GameObject proj = Instantiate(projectile, projectileSpawns[i].transform.position, firingDirection);
                proj.GetComponent<BaseProjectile>().FireProjectile(projectileSpawns[i], target, damage, fireRate);
                Rigidbody rocketRB = proj.GetComponent<Rigidbody>();
                rocketRB.AddForce(gameObject.transform.TransformDirection(Random.Range(-accuracy, accuracy), Random.Range(-accuracy, accuracy), 1) * shotVelocity);

                GetComponent<AudioSource>().Play();

 
                lastProjectilesShot.Add(proj);
            }
        }
    }
 
    public void SetTarget(GameObject targetObj){
        target = targetObj;
    }
 
    void RemoveLastProjectiles()
    {
        while(lastProjectilesShot.Count > 0){
            Destroy(lastProjectilesShot[0]);
            lastProjectilesShot.RemoveAt(0);
        }
    }
}