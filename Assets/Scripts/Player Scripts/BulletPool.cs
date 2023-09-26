using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public ExplosionParameters expPerams;
        public TurretStats bulPerams;
        public GameObject prefab;
        public int size;
    }

    //singleton
    public static BulletPool Instance;
    private void Awake()
    {
        Instance = this;
    }
    //end singleton

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.GetComponent<Explosion>().explosion = pool.expPerams;

                obj.GetComponent<Projectile>().SetFollowthrough(pool.bulPerams.destroysOtherShots);
                obj.GetComponent<Projectile>().SetExplosive(pool.bulPerams.explosiveProjectile);
                obj.GetComponent<Projectile>().SetDealsDamage(pool.bulPerams.dealDamage);
                obj.GetComponent<Projectile>().SetDamage(pool.bulPerams.damage);
                obj.GetComponent<Projectile>().SetEffects(pool.bulPerams.fireFX);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public float ProjectileSpeed(string tag)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("POOL WITH TAG " + tag + " DOES NOT EXIST");
            return 0;
        }
        float velocity = 0;
        foreach (Pool pool in pools)
        {
           if(pool.tag == tag)
            {
                velocity = pool.bulPerams.bulletVelocity;
            }
        }
        print("bug + " + velocity);
        return velocity;

    }

    public float ProjectileFireRate(string tag)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("POOL WITH TAG " + tag + " DOES NOT EXIST");
            return 0;
        }
        float fireRate = 0;
        foreach (Pool pool in pools)
        {
            if (pool.tag == tag)
            {
                fireRate = pool.bulPerams.fireRate;
            }
        }
        print("bug + " + fireRate);
        return fireRate;

    }

    public GameObject SpawnFromPool (string tag, Vector3 position, Quaternion rotation)
    {
        if(!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("POOL WITH TAG " + tag + " DOES NOT EXIST");
            return null;
        }

        GameObject objToSpawn = poolDictionary[tag].Dequeue();

        objToSpawn.SetActive(true);
        objToSpawn.transform.position = position;
        objToSpawn.transform.rotation = rotation;

        PooledObjects pooledObj = objToSpawn.GetComponent<PooledObjects>();
        if(pooledObj != null)
        {
            pooledObj.OnObjectSpawn();
        }
        poolDictionary[tag].Enqueue(objToSpawn);

        return objToSpawn;
    }
 
}
