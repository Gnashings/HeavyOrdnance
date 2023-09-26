using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimGun : MonoBehaviour
{
    public PlayerInputControls inputs;
    public Rigidbody rb;

    void Start()
    {
        inputs = gameObject.GetComponentInParent<PlayerInputControls>();
    }

    void FixedUpdate()
    {
        if(!PlayerProgress.paused)
        {
            if(inputs.gamePadMode)
            {
                PadAim();
            }
            else
            {
                Aim();
            }

        }
        
    }
    public float speed = 1.0f;
    Vector3 currentEulerAngles;
    private void Aim()
    {
        GameObject target;
        //float cameraRot = Camera.main.transform.rotation.eulerAngles.y;
        //Debug.Log(inputs.MouseLookAxis() * Mathf.Rad2Deg);

        /*
        target = inputs.MouseShootDown();

        float singleStep = speed * Time.deltaTime;
        Vector3 targetDir = target.transform.position - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDir, singleStep, 0.0f);
        newDirection.y = 0;
        Debug.DrawRay(transform.position, newDirection, Color.red);
        rb.rotation = Quaternion.LookRotation(newDirection);
        */

        float singleStep = 10 * Time.deltaTime;
        Vector3 targetDir = inputs.MouseAimDown() - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDir, singleStep, 0.0f);
        newDirection.y = 0;
        //Debug.DrawRay(transform.position, newDirection, Color.red);
        transform.rotation = Quaternion.LookRotation(newDirection);
        

    }

    private void PadAim()
    {
        //float cameraRot = Camera.main.transform.rotation.eulerAngles.y;

        transform.rotation = Quaternion.Euler(0f, inputs.GetPadLookAxis() * Mathf.Rad2Deg, 0f);
    }
}
