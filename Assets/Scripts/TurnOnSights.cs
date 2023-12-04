using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnSights : MonoBehaviour
{
    public LineRenderer sights;
    void Start()
    {
        sights.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(sights.enabled == false)
        {
            if (PlayerProgress.sightsOn == true)
            {
                sights.enabled = true;
            }
            else
                sights.enabled = false;
        }

    }
}
