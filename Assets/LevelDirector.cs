using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDirector : MonoBehaviour
{
    
    //[HideInInspector]
    public List<RoomSystem> rooms = new List<RoomSystem>();
    public bool roomsCompleted;
    // Start is called before the first frame update
    private void Awake()
    {
        //sets the current level for the level reset.
        PlayerProgress.curLevel = SceneManager.GetActiveScene().name.ToString();
        
        if (rooms.Count != 0)
        {
            Debug.LogWarning("Keep the room list to zero in the director script, this is a readonly field.");
        }
    }
    void Start()
    {
        roomsCompleted = false;

    }

    private void Update()
    {
        if(PlayerProgress.death == true)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }

    public void AddThisRoom(RoomSystem room)
    {
        rooms.Add(room);
    }

    public void CheckLevelCompletion()
    {
        //bool isCompleted = false;
        foreach (RoomSystem room in rooms)
        {
            if (room.roomCompleted == false)
            {
                roomsCompleted = false;
                return;
            }
            else
                roomsCompleted = true;
        }
        if(roomsCompleted == true)
        {
            PlayerProgress.levelsCompleted++;
            if (PlayerProgress.levelsCompleted == 4)
            {
                
                if (PlayerProgress.ChoseAbility() == false)
                {
                    SceneManager.LoadScene("WinScene2");
                }
                else if (PlayerProgress.ChoseAbility() == true)
                {
                    SceneManager.LoadScene("WinScene");
                }
                
            }
            else
            {
                StartCoroutine(levelTimeout());
                
            }
                
            
        }
    }

    private IEnumerator levelTimeout()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("PartsMenu");
    }
}
