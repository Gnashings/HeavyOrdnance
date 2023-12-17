using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTurret : MonoBehaviour
{
    public BoxCollider shotBox;
    public AudioSource autoGunAudio;
    public ParticleSystem particlesfx;
    public GameObject light;
    public float damage;
    public float cooldown;
    private float originalCooldown;
    private bool canDamage;

    public List<AudioClip> audioShots;

    private void Start()
    {
        originalCooldown = cooldown;
        canDamage = true;
        particlesfx.Stop();
        autoGunAudio.clip = audioShots[Random.Range(0, audioShots.Count)];
        //light.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (canDamage)
        {

            if (other.CompareTag("Enemy"))
            {
                particlesfx.Play();
                autoGunAudio.clip = audioShots[Random.Range(0, audioShots.Count)];
                autoGunAudio.Play();
                /*
                if (!autoGunAudio.isPlaying)
                {
                    autoGunAudio.clip = audioShots[Random.Range(0, audioShots.Count)];
                    autoGunAudio.Play();
                }*/
                other.gameObject.GetComponent<EnemyStats>().TakeDamage(damage);
                canDamage = false;

                StartCoroutine(Damage());
            }
            else
            {
                particlesfx.Stop();
                cooldown = originalCooldown;
                //light.SetActive(false);
            }

        }

    }


    private IEnumerator Damage()
    {
        canDamage = false;
        light.SetActive(false);
        yield return new WaitForSeconds(cooldown);
        if (cooldown > 0.02)
        {
            cooldown = cooldown * 0.90f;
        }

        //Debug.Log(cooldown + " CD speed");
        //light.SetActive(true);
        canDamage = true;
    }

    //when you are NOT firing, slow down down your ROF
    /*
    private IEnumerator Reset()
    {

    }*/
}
