using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineAbility : MonoBehaviour
{
    public PlayerInputControls inputs;
    public GameObject mine;
    public GameObject mineSpawn;
    public float abilityCD;
    private GameObject outMine;
    private bool mineOut = false;
    private bool canActivate;

    void Start()
    {
        outMine = null;
        canActivate = true;
        if (PlayerProgress.curGadgets==null || !PlayerProgress.curGadgets.Equals("Mine"))
        {
            this.enabled = false;
        }
        
    }

    void Update()
    {
        if(!PlayerProgress.paused)
        {
            LayMines();
        }
    }

    private void LayMines()
    {
        if (inputs.gadgetStart == true && !mineOut && canActivate)
        {
            if (mine != null)
            {
                //print("SPAWNING");
                GameObject bombInstance;
                Quaternion firingDirection = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 0, 0));
                bombInstance = Instantiate(mine, mineSpawn.transform.position, firingDirection) as GameObject;
                Rigidbody bombRB = bombInstance.GetComponent<Rigidbody>();
                bombRB.AddForce(gameObject.transform.TransformDirection(0, 1, -1f) * 300f);
                outMine = bombInstance;
            }
            mineOut = true;
        }
        else if(inputs.gadgetStart == true && mineOut && outMine != null)
        {
            outMine.GetComponent<Mine>().Detonate();
            //print("DETONATING");
            mineOut = false;
            StartCoroutine(Cooldown());
        }
    }

    private IEnumerator Cooldown()
    {
        canActivate = false;
        yield return new WaitForSeconds(5);
        canActivate = true;
    }
}
