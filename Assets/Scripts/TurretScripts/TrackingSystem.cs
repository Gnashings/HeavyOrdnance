using UnityEngine;
using System.Collections;
 
public class TrackingSystem : MonoBehaviour {
    [Tooltip("How fast do you want enemy to track onto you")]
    public float spinSpeed = 3.0f;
    public bool lookUpDown;
    [Tooltip("What is it tracking")]
    private GameObject target;
    
    Vector3 m_lastKnownPosition = Vector3.zero;
    Quaternion m_lookAtRotation;
 
    


  void Start()
    {
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player");

      
    }

    // Update is called once per frame
    void Update () {
        if(target){
            if(m_lastKnownPosition != target.transform.position){
                if(lookUpDown)
                {
                    m_lastKnownPosition = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
                }
                else
                    m_lastKnownPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

                m_lookAtRotation = Quaternion.LookRotation(m_lastKnownPosition - transform.position);
                //m_lookAtRotation.x = 0f;
            }
 
            if(transform.rotation != m_lookAtRotation){
                transform.rotation = Quaternion.RotateTowards(transform.rotation, m_lookAtRotation, spinSpeed * Time.deltaTime);
            }
        }
    }
 
    bool SetTarget(GameObject targetPoint)
    {
        if(target)
            return false;

        target = targetPoint;

        return true;
    }
}