using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class RoomSystem : MonoBehaviour
{
    public LevelDirector director;
    [Tooltip("Set all doors here")]
    public List<GameObject> doors = new List<GameObject>();
    [Tooltip("All enemy spawn points appear here")]
    // Transform[] spawnPointList;
    public List<Transform> spawnPointList = new List<Transform>();
    private BoxCollider trigger;
    private int enemyCount;
    private int enemiesKilled;
    [HideInInspector]
    public bool roomCompleted;

    void Start()
    {
        if (director == null)
        {
            Debug.LogError("No Game Director attached to this room, please attach the director.");
        }
        if (spawnPointList.Count != 0)
        {
            Debug.LogWarning("The SpawnPoints list should be empty, please attach SpawnPoints in the children instead.");
            //spawnPointList.Clear();
        }
        if (doors.Count != 0)
        {
            Debug.LogWarning("The Doors list should be empty, please attach Doors in the children instead.");
            //doors.Clear();
        }

        trigger = gameObject.GetComponent<BoxCollider>();

        //Set each child object to a spawnpoint or a door
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Door")) doors.Add(child.gameObject);
            if (child.CompareTag("SpawnPoint")) spawnPointList.Add(child.transform);
        }

        //spawnPointList = Array.FindAll(GetComponentsInChildren<Transform>(), child => child != this.transform && !child.CompareTag("Door"));

        director.AddThisRoom(this.GetComponent<RoomSystem>());
    }

    private void ReleaseEnemies()
    {
        foreach (Transform spawner in spawnPointList)
        {
            spawner.gameObject.GetComponent<SpawnEnemy>().TriggerEnemy();
            enemyCount++;
        }
    }
    public void LockDoors()
    {
        foreach (GameObject door in doors)
        {
            door.SetActive(true);
            //set the door text INEFFECTIVE
            door.GetComponentInChildren<TMP_Text>().text = enemyCount.ToString();
        }
    }
    private void UnlockDoors()
    {
        foreach (GameObject door in doors)
        {
            door.SetActive(false);
        }
    }

    //TODO CHANGE
    private void UpdateEnemyCounter(int enemies)
    {
        foreach (GameObject door in doors)
        {
            //set the door text INEFFECTIVE
            door.GetComponentInChildren<TMP_Text>().text = enemies.ToString();
        }
    }
    /*
    public void CheckDoorCanOpen()
    {
        //enemiesKilled++;
        //update the door text INEFFECTIVE
        UpdateEnemyCounter(enemyCount-enemiesKilled);
        //Debug.Log("Enemies Killed " + enemiesKilled + "enemyCount " + enemyCount);
        if(enemiesKilled == enemyCount)
        {
            UnlockDoors();
            ReportRoomCompleted();
        }
    }
    */
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            enemiesKilled = 0;
            trigger.enabled = false;
            ReleaseEnemies();
            LockDoors();
        }
    }

    private void ReportRoomCompleted()
    {
        roomCompleted = true;
        director.CheckLevelCompletion();
    }

    //delegate for each enemy killed.
    void ProcEnemyCount()
    {
        enemiesKilled++;
        UpdateEnemyCounter(enemyCount-enemiesKilled);
        //Debug.Log("enemiesKilled " + enemiesKilled + " enemyCount " + enemyCount);
        if(enemiesKilled == enemyCount)
        {
            UnlockDoors();
            ReportRoomCompleted();
        }
    }

    private void OnEnable() {
        EnemyStats.onDeath += ProcEnemyCount;
    }

    private void OnDisable() {
        EnemyStats.onDeath -= ProcEnemyCount;
    }

}
