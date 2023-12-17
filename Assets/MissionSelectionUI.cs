using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionSelectionUI : MonoBehaviour
{
    public void EnemyResetMods()
    {
        EnemyModifiers.ResetEnemyModifiers();
        Debug.Log("Whoa " + EnemyModifiers.healthMod);
    }

    public void EnemyHealthMod()
    {
        EnemyModifiers.healthMod = .20f;
        Debug.Log("Whoa " + EnemyModifiers.healthMod);
    }

    public void StartLevel()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void ReturnToShop()
    {
        SceneManager.LoadScene("PartsMenu");
    }
}
