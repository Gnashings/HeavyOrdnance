using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ImmortalDebugWatcher : MonoBehaviour
{
    public bool thisData;
    public bool proceed;
    public bool readData;
    private static ImmortalDebugWatcher instance;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

            if (proceed == true)
            {
                proceed = false;
                SceneManager.LoadScene("Menu");
            }
        
        if(readData)
        {
            PlayerProgress.ReadData();
            readData = false;
        }

    }
}
