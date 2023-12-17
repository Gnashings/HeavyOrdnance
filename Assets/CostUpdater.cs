using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class CostUpdater : MonoBehaviour
{
    private TMP_Text costText;
    void Start()
    {
        costText = gameObject.GetComponent<TMP_Text>();
    }

    public void UpdateCostText(EquipmentSlotInfo slotInfo)
    {
        if (PlayerProgress.CheckPartUnlock(slotInfo.identifier))
        {
            costText.text = "";
        }
        else
        {
            costText.text = "Cost: $ " + slotInfo.cost.ToString();
        }
    }

}
