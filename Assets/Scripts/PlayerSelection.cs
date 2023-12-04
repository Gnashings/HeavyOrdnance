using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelection : MonoBehaviour
{
    public GameObject turret;
    public GameObject body;
    public GameObject tracks;
    public GameObject gadgets;

    public TurretStats defTurret;
    public BodyStats defBody;
    public TrackStats defTrack;

    private string selection;
    private bool choseTurret;
    private bool choseBody;
    private bool choseTracks;
    private bool choseGadget;

    private TurretStats turretStats;

    void Start()
    {
        CheckChoices();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void TurretSelection(string thisString)
    {
        selection = thisString;
        choseTurret = true;
        choseBody = false;
        choseTracks = false;
        choseGadget = false;
        //print("turret " + thisString);
    }

    //CLEANER FUNCTION
    public void LoadTurret(TurretStats currentTurret)
    {
        turretStats = currentTurret;

    }

    public void BodySelection(string thisString)
    {
        selection = thisString;
        choseTurret = false;
        choseBody = true;
        choseTracks = false;
        choseGadget = false;
        //print("body " + thisString);
    }
    public void TrackSelection(string thisString)
    {
        selection = thisString;
        choseTurret = false;
        choseBody = false;
        choseTracks = true;
        choseGadget = false;
        //print("track " + thisString);
    }

    public void GadgetSelection(string thisString)
    {
        selection = thisString;
        choseTurret = false;
        choseBody = false;
        choseTracks = false;
        choseGadget = true;
        //print("track " + thisString);
    }

    public void PlayGame()
    {
        if (choseTurret == true)
        {
            PlayerProgress.SetTurret(selection);
            PlayerProgress.SetTurretStats(turretStats);
        }
        if (choseBody == true)
        {
            PlayerProgress.SetBody(selection);
        }
        if (choseTracks == true)
        {
            PlayerProgress.SetTracks(selection);
        }
        if (choseGadget == true)
        {
            PlayerProgress.SetGadget(selection);
        }
        DetermineLevel();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void CheckChoices()
    {
        if (PlayerProgress.hasTurret == true)
        {
            turret.SetActive(false);
        }
        else
        {
            PlayerProgress.SetTurretStats(defTurret);
        }

        if (PlayerProgress.hasBody == true)
        {
            body.SetActive(false);
        }

        if (PlayerProgress.hasTracks == true)
        {
            tracks.SetActive(false);
        }

        if (PlayerProgress.hasGadgets == true)
        {
            gadgets.SetActive(false);
        }
    }

    private void DetermineLevel()
    {
        //CHANGED FOR TESTING
        if (PlayerProgress.levelsCompleted == 0)
        {
            SceneManager.LoadScene("Level 1");
        }
        if (PlayerProgress.levelsCompleted == 1)
        {
            SceneManager.LoadScene("Level 1");
            //SceneManager.LoadScene("Level 2");
        }
        if (PlayerProgress.levelsCompleted == 2)
        {
            SceneManager.LoadScene("Level 1");
            //SceneManager.LoadScene("Level 3");
        }
        if (PlayerProgress.levelsCompleted == 3)
        {
            SceneManager.LoadScene("Level 1");
            //SceneManager.LoadScene("Level 4");
        }
    }
}
