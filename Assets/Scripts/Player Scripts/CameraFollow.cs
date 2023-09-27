using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    private Vector3 newtrans;
    public AnimationCurve curve;
    public float shakeDuration = 1f;

    private bool isShaking;
    // Start is called before the first frame update
    void Start()
    {
        offset.x = transform.position.x - player.transform.position.x;
        offset.z = transform.position.z - player.transform.position.z;
        newtrans = transform.position;
        //not taking y as we won't update y position. 

    }
    void LateUpdate()
    {
        newtrans.x = player.transform.position.x + offset.x;
        newtrans.z = player.transform.position.z + offset.z;
        transform.position = newtrans;
    }

    void Update()
    {

    }

    IEnumerator CamShake()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / shakeDuration);
            newtrans = startPosition + Random.insideUnitSphere;
            yield return null;
        }

        transform.position = startPosition;
    }

    void ShakeThatCam()
    {
        if (isShaking == false)
        {
            StartCoroutine(CamShake());
        }



    }

    void OnEnable()
    {
        EnemyStats.onDeath += ShakeThatCam;
    }

    void OnDisable()
    {
        EnemyStats.onDeath -= ShakeThatCam;
    }
}
