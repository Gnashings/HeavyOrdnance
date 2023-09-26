using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Stats")]
    public float totalHealth;
    public float totalArmor;
    public float health;
    public float armor;
    public float armorBreakTimer;
    public AudioSource armorBreakSound;
    //private stats
    private float armorRecharge;
    private bool hasGustavAbility;
    private bool canBomba;
    private float armorRechargeTimer = 0.05f;
    //defensive stats
    private bool canRecharge;
    private float flatDR;

    [Header("Body Abilities")]
    public BodyMods bodyMods;
    public float bombaCooldown;
    public float gustavArmorReduction;
    public GameObject autoGun;
    public BodyStats noBodyMod;
    public BodyStats gustav;
    public BodyStats bigBomba;
    public BodyStats reaper;

    [Header("Turret Abilities")]
    public TurretMods turrets;
    public TurretStats noGunMod;
    public TurretStats riskyBusiness;
    public TurretStats sasha;
    public TurretStats newtonsApple;

    [Header("Track Abilities")]
    public TrackMods tracks;
    public TrackStats noTrackMod;
    public TrackStats nuclearWinter;
    public TrackStats hare;
    public TrackStats tortoise;

    [Header("Gadget Abilities")]
    public GadgetMods gadgets;
    public TurretStats Shockwave;
    public float RoidDamageIncrease;
    public float gadgetCD;
    public float armorBonusRch;
    private bool enraged;

    [Header("Editable Scripts")]
    public TankBodyController tankbody;
    public FireGun firegun;
    public Explosion bigBombaBomb;
    public AudioClip bombaExplosionSound;
    public GameObject basicTurretModal;
    public GameObject sashaModel;
    public GameObject newtonsAppleModel;
    public GameObject basicBodyModel;
    public GameObject gustavModel;
    public GameObject bigBombaModel;
    public PlayerInputControls input;

    private void Awake()
    {
        UnloadModels();
        LoadPlayerSettings();
        ResetAllStats();
        CheckBodyMod();
        CheckTurretMods();
        CheckTrackMods();
        CheckGadgetMods();
        SetHealthAndArmor();
        StartCoroutine(ArmorRecharge());
        //print(PlayerProgress.ChoseAbility());
    }

    void Start()
    {
        //PlayerProgress.ReadData();
    }

    void Update()
    {
        if(!PlayerProgress.paused)
        {
            if(PlayerProgress.curGadgets != null && PlayerProgress.curGadgets.Equals("Steroid"))
            {
                if (input.gadgetStart && !enraged)
                {
                    Debug.Log("repairing...");
                    PlayerProgress.roidDmgMod = RoidDamageIncrease;
                    StartCoroutine(ArmorRepair());
                }
            }
        }
    }

    private IEnumerator ArmorRepair()
    {
        if (!enraged)
        {
            enraged = true;
        }
        yield return new WaitForSeconds(armorBreakTimer);
        Debug.Log("repairing completed");
        PlayerProgress.roidDmgMod = 0;
        yield return new WaitForSeconds(gadgetCD);
        enraged = false;
    }

    private float BufferArmorRecharge()
    {
        if (PlayerProgress.roidDmgMod == 0)
            return 0;
        else
            return armorBonusRch;
    }

    #region BodyMods

    private void CheckBodyMod()
    {
        //No Mod
        if (bodyMods.HasFlag(BodyMods.noMod))
        {
            gameObject.transform.GetComponentInChildren<TankBodyController>().topSpeed = noBodyMod.topSpeed;
            totalHealth = noBodyMod.health;
            totalArmor = noBodyMod.armor;
            armorRecharge = noBodyMod.armorRecharge;
            armorBreakTimer = noBodyMod.armorBreakTimer;
            canBomba = false;
            
        }

        //Big Bomba
        if (bodyMods.HasFlag(BodyMods.bigBomba))
        {
            gameObject.GetComponentInChildren<TankBodyController>().topSpeed = noBodyMod.topSpeed;
            totalHealth = noBodyMod.health;
            totalArmor = noBodyMod.armor;
            armorRecharge = bigBomba.armorRecharge;
            armorBreakTimer = bigBomba.armorBreakTimer;
            canBomba = true;
            
        }

        //Gustav
        if (bodyMods.HasFlag(BodyMods.gustav))
        {
            gameObject.GetComponentInChildren<TankBodyController>().topSpeed = gustav.topSpeed;
            totalHealth = gustav.health;
            totalArmor = gustav.armor;
            hasGustavAbility = true;
            canBomba = false;
            armorRecharge = gustav.armorRecharge;
            armorBreakTimer = gustav.armorBreakTimer;
            
            //failsafe gustav ability
            if (hasGustavAbility)
            {
                if (gustavArmorReduction <= 0)
                    gustavArmorReduction = 3;  
                else
                    flatDR = gustavArmorReduction;
            }
        }

        //Reaper
        if (bodyMods.HasFlag(BodyMods.reaper))
        {
            gameObject.GetComponentInChildren<TankBodyController>().topSpeed = reaper.topSpeed;
            totalHealth = reaper.health;
            totalArmor = reaper.armor;
            armorRecharge = reaper.armorRecharge;
            armorBreakTimer = reaper.armorBreakTimer;
            canBomba = false;
            autoGun.SetActive(true);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Enemy") && canBomba)
        {
            if(canBomba == true)
            {
                canBomba = false;
                bigBombaBomb.Explode();
                //Debug.Log("bombabomb");
                StartCoroutine(BombaCooldown());
            }
        }    
    }
    IEnumerator BombaCooldown()
    {
        yield return new WaitForSeconds(bombaCooldown);

        canBomba = true;
    }

    public enum BodyMods
    {
        noMod,
        bigBomba,
        gustav,
        reaper,
    };

    #endregion BodyMods

    #region TurretMods

    private void CheckTurretMods()
    {
        
        if (turrets.HasFlag(TurretMods.noMod))
        {
            firegun.SetGunValues(   noGunMod.fireRate,
                                    noGunMod.bulletVelocity,
                                    noGunMod.bulletSpread,
                                    "NormalShot");
            
        }
        if (turrets.HasFlag(TurretMods.riskyBusiness))
        {
            firegun.SetGunValues(riskyBusiness.fireRate,
                                    riskyBusiness.bulletVelocity,
                                    riskyBusiness.bulletSpread,
                                    "RiskyBusiness");
        }
        if (turrets.HasFlag(TurretMods.sasha))
        {
            firegun.SetGunValues(sasha.fireRate,
                                    sasha.bulletVelocity,
                                    sasha.bulletSpread,
                                    "Sasha");
            
        }
        if (turrets.HasFlag(TurretMods.newtonsApple))
        {
            firegun.SetGunValues(newtonsApple.fireRate,
                                    newtonsApple.bulletVelocity,
                                    newtonsApple.bulletSpread,
                                    "Newtons");
            
        }
    }

    #endregion TurretMods

    #region TrackMods

    private void CheckTrackMods()
    {
        if (tracks.HasFlag(TrackMods.noMod))
        {
            tankbody.ignoreAcceleration = noTrackMod.ignoreAcceleration;
            tankbody.slowImmune = noTrackMod.ignoreSlow;
            tankbody.acceleration = noTrackMod.acceleration;
            tankbody.rotationSpeed = noTrackMod.turningSpeed;
            tankbody.rb.mass = 100;
            tankbody.rb.drag = 5;
            tankbody.rb.angularDrag = 4;
        }
        if (tracks.HasFlag(TrackMods.nuclearWinter))
        {
            tankbody.ignoreAcceleration = nuclearWinter.ignoreAcceleration;
            tankbody.slowImmune = nuclearWinter.ignoreSlow;
            tankbody.acceleration = nuclearWinter.acceleration;
            tankbody.rotationSpeed = nuclearWinter.turningSpeed;
            tankbody.rb.mass = 100;
            tankbody.rb.drag = 4;
            tankbody.rb.angularDrag = 3;
        }
        if (tracks.HasFlag(TrackMods.hare))
        {
            tankbody.ignoreAcceleration = hare.ignoreAcceleration;
            tankbody.slowImmune = hare.ignoreSlow;
            tankbody.acceleration = hare.acceleration;
            tankbody.rotationSpeed = hare.turningSpeed;
            tankbody.rb.mass = 100;
            tankbody.rb.drag = 5;
            tankbody.rb.angularDrag = 4;
        }
        if (tracks.HasFlag(TrackMods.tortoise))
        {
            tankbody.ignoreAcceleration = tortoise.ignoreAcceleration;
            tankbody.slowImmune = tortoise.ignoreSlow;
            tankbody.acceleration = tortoise.acceleration;
            tankbody.rotationSpeed = tortoise.turningSpeed;
            tankbody.rb.mass = 10;
            tankbody.rb.drag = 5;
            tankbody.rb.angularDrag = 4;
        }
    }

    public enum TrackMods
    {
        noMod,
        nuclearWinter,
        hare,
        tortoise,
    };

    #endregion Trackmods

    #region ArmorAndHealth
    public void TakeDamage(float damage)
    {
        ProcSlow();
        if (armor > 0)
        {
            //check for damage reduciton
            if (PlayerProgress.curBody != null && PlayerProgress.curBody.Equals("Gustav"))
            {
                damage = GustavArmorCalculations(damage);
            }
            //ignore damage if reduced heavily
            if (damage <= 0)
            {
                return;
            }

            //split the damage and calculate the results correctly.
            if (armor - damage <= 0)
            {
                float leftOverDamage;
                leftOverDamage = damage - armor;
                armor = 0;
                health -= leftOverDamage;
                StartCoroutine(ArmorBreakCooldown());
                armorBreakSound.Play();
                if (PlayerProgress.godMode == false)
                {
                    if (health <= 0)
                    {
                        Die();
                    }
                }
                return;
            }
            else
                armor -= damage;
        }
        else
            health -= damage;

        if (PlayerProgress.godMode == false)
        {
            if (health <= 0)
            {
                Die();
            }
        }    

    }

    public void HealToFull()
    {
        armor = totalArmor;
    }

    private float GustavArmorCalculations(float damage)
    {
        //print("Damage Before: " + damage);
        if(damage <= 15)
        {
            damage -= flatDR;
        }
        else
        {
            damage *= 0.8f;
        }

        //print("Damage After: " + damage);
        return damage;
    }

    IEnumerator ArmorBreakCooldown()
    {
        canRecharge = false;
        yield return new WaitForSeconds(armorBreakTimer);
        canRecharge = true;
    }

    IEnumerator ArmorRecharge()
    {
        while(true)
        {
            if (armor < totalArmor)
            {
                if(canRecharge == false)
                {
                    yield return null;
                }
                else
                    armor += (armorRecharge * armorRechargeTimer) + BufferArmorRecharge();
                yield return new WaitForSeconds(armorRechargeTimer);
            }
            else
            {
                yield return null;
            }
        }
        
    }
    private void SetHealthAndArmor()
    {
        health = totalHealth;
        armor = totalArmor;
    }

    #endregion ArmorAndHealth

    public void ProcSlow()
    {
        tankbody.isSlowed = true;
    }

    private void ResetAllStats()
    {
        health = 0;
        armor = 0;
        totalHealth = 0;
        totalArmor = 0;
        flatDR = 0;
        armorRecharge = 0;
        canBomba = false;
        canRecharge = true;
        autoGun.SetActive(false);
    }

    public void Die()
    {
        Debug.Log("you died");
        PlayerProgress.death = true;
        armorRecharge = 0;
    }

    public enum TurretMods
    {
        noMod,
        riskyBusiness,
        sasha,
        newtonsApple,
    };

    private void LoadPlayerSettings()
    {
        //turret
        if (PlayerProgress.hasTurret == false)
        {
            turrets = TurretMods.noMod;
            basicTurretModal.SetActive(true);
        }
        else
        {
            if (PlayerProgress.curTurret.Equals("RiskyBusiness"))
            {
                turrets = TurretMods.riskyBusiness;
                basicTurretModal.SetActive(true);
            }
            if (PlayerProgress.curTurret.Equals("Sasha"))
            {
                turrets = TurretMods.sasha;
                sashaModel.SetActive(true);
            }
            if (PlayerProgress.curTurret.Equals("NewtonsApple"))
            {
                turrets = TurretMods.newtonsApple;
                newtonsAppleModel.SetActive(true);
            }
        }

        //body
        if (PlayerProgress.hasBody == false)
        {
            bodyMods = BodyMods.noMod;
            basicBodyModel.SetActive(true);
        }
        else
        {
            if (PlayerProgress.curBody.Equals("BigBomba"))
            {
                bodyMods = BodyMods.bigBomba;
                bigBombaModel.SetActive(true);
            }
            if (PlayerProgress.curBody.Equals("Reaper"))
            {
                bodyMods = BodyMods.reaper;
                basicBodyModel.SetActive(true);
            }
            if (PlayerProgress.curBody.Equals("Gustav"))
            {
                bodyMods = BodyMods.gustav;
                gustavModel.SetActive(true);
            }
        }

        //tracks
        if (PlayerProgress.hasTracks == false)
        {
            tracks = TrackMods.noMod;
        }
        else
        {
            if (PlayerProgress.curTracks.Equals("NuclearWinter"))
            {
                tracks = TrackMods.nuclearWinter;
            }
            if (PlayerProgress.curTracks.Equals("Hare"))
            {
                tracks = TrackMods.hare;
            }
            if (PlayerProgress.curTracks.Equals("Tortoise"))
            {
                tracks = TrackMods.tortoise;
            }
        }

        //Gadget
        if (PlayerProgress.hasGadgets == false)
        {
            gadgets = GadgetMods.noMod;
        }
        else
        {
            if (PlayerProgress.curGadgets.Equals("Shockwave"))
            {
                gadgets = GadgetMods.shockwave;
            }
            if (PlayerProgress.curGadgets.Equals("Mine"))
            {
                gadgets = GadgetMods.mineBomb;
            }
            if (PlayerProgress.curGadgets.Equals("Steroid"))
            {
                gadgets = GadgetMods.steroid;
            }
        }
    }
    public enum GadgetMods
    {
        noMod,
        shockwave,
        steroid,
        mineBomb,
    };

    private void CheckGadgetMods()
    {
        if (gadgets.HasFlag(GadgetMods.steroid))
        {
            //tod
        }
        if (gadgets.HasFlag(GadgetMods.shockwave))
        {
            //todo
            firegun.SetSecondaryGunValues(Shockwave.fireRate, Shockwave.bulletVelocity, Shockwave.bulletSpread, "Shockwave");
        }
        if (gadgets.HasFlag(GadgetMods.mineBomb))
        {
            //todo
        }
    }
    
    private void UnloadModels()
    {
        basicTurretModal.SetActive(false);
        sashaModel.SetActive(false);
        newtonsAppleModel.SetActive(false);
        basicBodyModel.SetActive(false);
        gustavModel.SetActive(false);
        bigBombaModel.SetActive(false);
    }
}
