using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabEventCamera : MonoBehaviour
{
    public Camera cam;
    // Start is called before the first frame update
    void Awake()
    {
        cam = Camera.main;
        gameObject.GetComponent<Canvas>().worldCamera = cam;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
