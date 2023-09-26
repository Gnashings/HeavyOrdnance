using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    private GameObject player;
    private PlayerStats playerStats;
    private PlayerInputControls playerInputs;
    public Slider health;
    public Slider armor;
    public Slider reload;
    public Canvas pauseMenu;
    public TMP_Text armorText;

    void Start()
    {
        player = GameObject.Find("Player");
        playerStats = player.GetComponent<PlayerStats>();
        playerInputs = player.GetComponent<PlayerInputControls>();

        //health
        health.maxValue = playerStats.totalHealth;
        health.value = playerStats.health;

        //armor
        armor.maxValue = playerStats.totalArmor;
        armor.value = playerStats.armor;
        armorText.text = playerStats.totalArmor.ToString();

        //reload
        reload.maxValue = 1f;
        reload.value = reload.maxValue;
        reload.handleRect.gameObject.SetActive(true);

        if (PlayerProgress.hideGunReload == true)
        {
            reload.gameObject.SetActive(false);
            Debug.Log("Hiding UI");
        }
    }

    // Update is called once per frame
    void Update()
    {
        armor.value = playerStats.armor;
        health.value = playerStats.health;
        armorText.text = armor.value.ToString();
        if (playerInputs.paused)
        {
            if (pauseMenu.enabled)
            {
                GameUnpause();
            }
            else GamePause();
        }

        //handles reload bar
        if (reload.enabled == true)
        {
            if (reload.value < reload.maxValue)
            {
                FillReloadBar();
            }
        }

    }

    private void GamePause()
    {
        PlayerProgress.paused = true;
        pauseMenu.enabled = true;
        Time.timeScale = 0;
        playerInputs.UnlockMouse();
    }

    public void GameUnpause()
    {
        PlayerProgress.paused = false;
        pauseMenu.enabled = false;
        Time.timeScale = 1;
        playerInputs.LockMouse();
    }

    public void MainMenuInputCleanup()
    {
        PlayerProgress.paused = false;
        pauseMenu.enabled = false;
        Time.timeScale = 1;
        playerInputs.UnlockMouse();
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }

    void TriggerReloadBar(float timer)
    {
        reload.minValue = Time.time;
        reload.maxValue = Time.time + timer;
        reload.handleRect.gameObject.SetActive(false);

    }

    void FillReloadBar()
    {
        reload.value = Time.time;
        if (reload.value >= reload.maxValue)
        {
            reload.handleRect.gameObject.SetActive(true);
        }
    }

    public void OnEnable()
    {
        if (PlayerProgress.hideGunReload == false)
        {
            FireGun.reloadGun += TriggerReloadBar;
        }
    }

    public void OnDisable()
    {
        if (PlayerProgress.hideGunReload == false)
        {
            FireGun.reloadGun -= TriggerReloadBar;
        }
    }

}