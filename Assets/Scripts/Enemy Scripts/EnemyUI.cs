using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class EnemyUI : MonoBehaviour
{
    public Canvas canvas;
    public TMP_Text textMeshPro;
    public Transform cameraPos;
    public EnemyStats enemyStats;
    private Camera cam;
    public Transform enemyPos;
    void Awake()
    {
        cam = Camera.main;
        gameObject.GetComponent<Canvas>().worldCamera = cam;
        cameraPos = cam.transform;
        //enemyPos = gameObject.transform.root;
        //Debug.Log("Parent " + gameObject.transform.root.name);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transform.position + cameraPos.forward);
        //transform.position = enemyPos.position;
        textMeshPro.text = enemyStats.health.ToString();
    }

}
