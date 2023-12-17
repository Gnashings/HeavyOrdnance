using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckItemUnlock : MonoBehaviour
{
    private string partName;

    void Start()
    {
        partName = gameObject.GetComponentInParent<PartButton>().equipmentSlotInfo.identifier;
    }

    void RemoveLockIcon()
    {
        if (PlayerProgress.CheckPartUnlock(partName))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        PlayerSelection.onConfirmUnlock += RemoveLockIcon;
    }

    private void OnDisable()
    {
        PlayerSelection.onConfirmUnlock -= RemoveLockIcon;
    }



}
