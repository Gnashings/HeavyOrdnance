using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{

    void Start ()
    {
        if(SceneManager.GetActiveScene().name.Equals("MainMenu"))
        {

            PlayerProgress.ResetPlayerStats();
        }
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Play()
    {
        SceneManager.LoadScene("PartsMenu");
    }

    public void Main()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ResetLevel()
    {
        Debug.Log(PlayerProgress.curLevel);
        PlayerProgress.death = false;
        SceneManager.LoadScene(PlayerProgress.curLevel);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
