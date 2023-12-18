using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public static class PlayerProgress
{
    public static bool hasTurret;
    public static bool hasBody;
    public static bool hasTracks;
    public static bool hasGadgets;
    public static string curTurret;
    public static string curBody;
    public static string curTracks;
    public static string curGadgets;

    //inventory
    public static List<string> unlockedItems;

    public static bool paused;
    public static string curLevel;
    public static int levelsCompleted;
    public static bool death;
    public static float roidDmgMod;

    //UI changes
    public static bool hideGunReload;
    //TODO change to this
    public static TurretStats turretInfo;
    public static BodyStats bodyInfo;
    public static TrackStats trackInfo;

    public static float payout;
    //Money stats
    public static float money;

    //options
    public static bool godMode;
    public static bool sightsOn;
    public static float vol;

    public static void SetTurret(string selection)
    {
        curTurret = selection;
        hasTurret = true;
    }

    public static void SetTurretStats(TurretStats selection)
    {
        turretInfo = selection;
        hideGunReload = selection.hideUI;
    }

    public static void SetBody(string selection)
    {
        curBody = selection;
        hasBody = true;
    }

    public static void SetBodyStats(BodyStats selection)
    {
        bodyInfo = selection;
    }

    public static void SetTracks(string selection)
    {
        curTracks = selection;
        hasTracks = true;
    }

    public static void SetTrackStats(TrackStats selection)
    {
        trackInfo = selection;
    }

    public static void SetGadget(string selection)
    {
        curGadgets = selection;
        hasGadgets = true;
        //Debug.Log("selec" + selection);
    }

    public static void ReadData()
    {
        Debug.Log("Turret: " + hasTurret);
        Debug.Log("Body: " + hasBody);
        Debug.Log("Tracks " + hasTracks);
        Debug.Log("Gadget " + hasGadgets + " " + curGadgets);
    }

    public static bool ChoseAbility()
    {
        bool hasAbility = false;
        if (hasTurret)
        {
            hasAbility = true;
        }
        if (hasBody)
        {
            hasAbility = true;
        }
        if (hasTracks)
        {
            hasAbility = true;
        }
        return hasAbility;

    }

    public static bool CheckPartUnlock(string thisString)
    {
        if (PlayerProgress.unlockedItems == null)
        {
            return false;
        }
        for (int i = 0; i < PlayerProgress.unlockedItems.Count; i++)
        {
            if (PlayerProgress.unlockedItems[i].Equals(thisString))
                return true;
        }
        return false;
    }

    public static void ResetPlayerStats()
    {
        roidDmgMod = 0;

        hasTurret = false;
        hasBody = false;
        hasTracks = false;
        hasGadgets = false;

        curTurret = null;
        curBody = null;
        curTracks = null;
        curGadgets = null;

        death = false;

        levelsCompleted = 0;

        //UI RESETS
        hideGunReload = false;

        unlockedItems = null;
        turretInfo = null;
        bodyInfo = null;
        trackInfo = null;
        //no money no prollems
        money = 0;

        Debug.Log("all stats resets");
    }

}
