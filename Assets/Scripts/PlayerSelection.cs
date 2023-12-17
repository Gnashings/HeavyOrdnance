using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSelection : MonoBehaviour
{
    public GameObject turret;
    public GameObject body;
    public GameObject tracks;
    public GameObject gadgets;

    public GameObject buy;
    public GameObject equip;
    public CostUpdater costUpdater;

    public TurretStats defTurret;
    public BodyStats defBody;
    public TrackStats defTrack;

    public bool ignoreCosts;


    private string selection;
    public EquipmentSlotInfo selectedPart;


    private bool choseTurret;
    private bool choseBody;
    private bool choseTracks;
    private bool choseGadget;

    private TurretStats turretStats;
    private TurretStats selectedTurret;

    private BodyStats bodyStats;
    private BodyStats selectedBody;

    private TrackStats trackStats;
    private TrackStats selectedTracks;

    //dele
    public delegate void OnConfirmUnlock();
    public static OnConfirmUnlock onConfirmUnlock;

    public delegate void OnConfirmEquip();
    public static OnConfirmEquip onConfirmEquip;

    void Start()
    {
        CheckChoices();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        onConfirmUnlock?.Invoke();

        buy.SetActive(false);
        equip.SetActive(false);
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

    public void BodySelection(string thisString)
    {
        selection = thisString;
        choseTurret = false;
        choseBody = true;
        choseTracks = false;
        choseGadget = false;
        //print("body " + thisString);
    }

    public void LoadBody(BodyStats currentBody)
    {
        TruncatePartSelection();
        selectedBody = currentBody;
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

    public void LoadPart(EquipmentSlotInfo equipment)
    {
        selectedPart = equipment;
        SetSelectedEquipment();
        if (CheckPartUnlock(equipment.identifier) == true)
        {
            DisplayEquip();
            Debug.Log("We have the part");
        }
        else
        {
            DisplayBuy();
            Debug.Log("We DO NOT have the part");
            choseTurret = false;
        }
    }

    private void SetSelectedEquipment()
    {
        TruncatePartSelection();
        if (selectedPart.turretStats != null)
        {
            selectedTurret = selectedPart.turretStats;
            return;
        }

        if (selectedPart.bodyStats != null)
        {
            selectedBody = selectedPart.bodyStats;
            return;
        }

        if (selectedPart.trackStats != null)
        {
            selectedTracks = selectedPart.trackStats;
            return;
        }
    }

    private void DisplayBuy()
    {
        equip.SetActive(false);
        buy.SetActive(true);
    }

    private void DisplayEquip()
    {
        equip.SetActive(true);
        buy.SetActive(false);
    }

    public void BuyEquipment()
    {
        if (ignoreCosts == false)
        {
            if (selection == null ||
                selectedPart == null ||
                PlayerProgress.money < selectedPart.cost)
            {
                Debug.Log("no funds");
                return;
            }
        }


        //first item bought?
        if (PlayerProgress.unlockedItems == null)
        {
            //create a new parts list
            List<string> newItemsList = new List<string>();
            newItemsList.Add(selection);
            PlayerProgress.unlockedItems = newItemsList;
            onConfirmUnlock?.Invoke();

            //gimme ya money
            PlayerProgress.money -= selectedPart.cost;

            Debug.Log("Added " + PlayerProgress.unlockedItems.Count);
            Debug.Log("Added " + selectedPart.identifier);
            costUpdater.UpdateCostText(selectedPart);
            DisplayEquip();
        }

        //if you DONT have this part.
        if (CheckPartUnlock(selectedPart.identifier) == false)
        {
            PlayerProgress.unlockedItems.Add(selection);
            onConfirmUnlock?.Invoke();

            //gimme ya money
            PlayerProgress.money -= selectedPart.cost;

            Debug.Log("Added " + PlayerProgress.unlockedItems.Count);
            Debug.Log("Added " + selectedPart.identifier);
            costUpdater.UpdateCostText(selectedPart);
            DisplayEquip();
        }

    }

    public void EquipPart()
    {
        if (selectedPart.partType.Equals(EquipmentSlotInfo.PartType.Turret))
        {
            Debug.Log("selectedPart TURRET : " + selectedPart.partType.HasFlag(EquipmentSlotInfo.PartType.Turret));
            Debug.Log("selectedPart TURRET : " + selectedPart);
            Debug.Log("selectedPart TURRET : " + selectedPart.partType);
            turretStats = selectedTurret;
            PlayerProgress.SetTurret(selectedPart.identifier);
            PlayerProgress.SetTurretStats(selectedTurret);
            onConfirmEquip?.Invoke();
            return;
        }
        if (selectedPart.partType.Equals(EquipmentSlotInfo.PartType.Armor))
        {
            //Debug.Log("selectedPart BODY : " + selectedPart.partType.HasFlag(EquipmentSlotInfo.PartType.Armor));
            bodyStats = selectedBody;
            PlayerProgress.SetBody(selectedPart.identifier);
            PlayerProgress.SetBodyStats(selectedBody);
            onConfirmEquip?.Invoke();
            return;
        }
        if (selectedPart.partType.Equals(EquipmentSlotInfo.PartType.Track))
        {
            //Debug.Log("selectedPart TRACKS : " + selectedPart.partType.HasFlag(EquipmentSlotInfo.PartType.Track));
            trackStats = selectedTracks;
            PlayerProgress.SetTracks(selectedPart.identifier);
            PlayerProgress.SetTrackStats(selectedTracks);
            onConfirmEquip?.Invoke();
            return;
        }
    }

    private void TruncatePartSelection()
    {
        selectedTurret = null;
        selectedBody = null;
        selectedTracks = null;
    }

    public bool CheckPartUnlock(string thisString)
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

    public void PlayGame()
    {
        /*
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
        */
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
            //turret.SetActive(false);
        }
        else
        {
            PlayerProgress.SetTurretStats(defTurret);
        }

        if (PlayerProgress.hasBody == true)
        {
            //body.SetActive(false);
        }

        if (PlayerProgress.hasTracks == true)
        {
            //tracks.SetActive(false);
        }

        if (PlayerProgress.hasGadgets == true)
        {
            //gadgets.SetActive(false);
        }
    }

    private void DetermineLevel()
    {
        SceneManager.LoadScene("MissionMenu");
        //CHANGED FOR TESTING
        /*
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
        */
    }
}
