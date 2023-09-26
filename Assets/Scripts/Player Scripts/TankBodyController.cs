using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// handles all rigidbody functionality for the tank
/// </summary>
public class TankBodyController : MonoBehaviour
{
    public PlayerInputControls inputs;
    [HideInInspector]
    public Rigidbody rb;
    public float acceleration;
    public float speed;
    
    public float rotationSpeed;
    [HideInInspector]
    public float topSpeed;
    
    public bool ignoreAcceleration;
    private bool countingSlow;

    [Header("Slow Debuff")]
    [Tooltip("Do not go above 1")]
    public float slowAmount;
    public float slowDuration;
    public bool isSlowed;
    public float roidDebuffAmount;

    [Header("Effects")]
    public AudioSource engineNoise;
    public ParticleSystem dirtright;
    public ParticleSystem dirtleft;

    [HideInInspector]
    public bool slowImmune;
    public float backPenalty;
    
    void Start()
    {
        inputs = gameObject.GetComponent<PlayerInputControls>();
        rb = gameObject.GetComponentInChildren<Rigidbody>();
        speed = 0;
        if(roidDebuffAmount == 0)
        {
            roidDebuffAmount = 1;
        }
    }
    
    private void FixedUpdate()
    {
        if (isSlowed)
        {
            if(!countingSlow)
            {
                StartCoroutine(SlowTimer());
            }
        }
        Move();
        Rotate();
    }
    
    private void Move()
    {
        if (inputs.GetPadMoveForwardAxis().magnitude == 0)
        {
            /*weird thing where you lose speed over time instead of instantly
            if(speed > 0){speed -= acceleration * Time.deltaTime;}*/
            StopDirtEffects();
            speed = 0;
        }
        if (inputs.GetPadMoveForwardAxis().z != 0)
        {
            CalculateMovementSpeed();
        }
  
    }

    private void CalculateMovementSpeed()
    {

        if (rb.velocity.magnitude < topSpeed * SlowDebuffs())
        {
            if (!ignoreAcceleration)
            {
                if (speed <= topSpeed * SlowDebuffs()) speed += acceleration * Time.deltaTime;
            }
            else
            {
                speed = topSpeed * SlowDebuffs();
            }
            StartDirtEffects();
            rb.velocity += Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * inputs.GetPadMoveForwardAxis() * speed;
        }
    }

    private void Rotate()
    {
        Quaternion deltaRotation = Quaternion.Euler(rotationSpeed * inputs.GetMoveRotationAxis());
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    private float SlowDebuffs()
    {
        return BackPenalty() * RoidSlow() * ForceSlow();
    }

    private float ForceSlow()
    {
        if (slowImmune)
        {
            return 1;
        }
        if(slowAmount < 0)
        {
            Debug.LogWarning("slowAmount is below 0, please set higher");
            return 1;
        }
        if(slowAmount > 1)
        {
            Debug.LogWarning("slowAmount is over 1, please set lower");
            return 1;
        }
        if (isSlowed)
        {
            return slowAmount;
        }
        else
            return 1;
    }

    private float BackPenalty()
    {
        if (inputs.GetPadMoveForwardAxis().z >= 0)
        {
            return 1;
        }
        else return backPenalty;
    }

    private float RoidSlow()
    {
        if (PlayerProgress.roidDmgMod == 0)
        {
            return 1;
        }
        else return roidDebuffAmount;
    }

    private void StartDirtEffects()
    {
        engineNoise.volume = 0.015f;
        if (!dirtright.isPlaying)
        {
            dirtright.Play();
        }
        if (!dirtleft.isPlaying)
        {
            dirtleft.Play();
        }
    }

    private void StopDirtEffects()
    {
        engineNoise.volume = 0.04f;
        if (dirtright.isPlaying)
        {
            dirtright.Stop();
        }
        if (dirtleft.isPlaying)
        {
            dirtleft.Stop();
        }
    }

    IEnumerator SlowTimer()
    {
        countingSlow = true;
        yield return new WaitForSeconds(slowDuration);
        countingSlow = false;
        isSlowed = false;
    }
}
