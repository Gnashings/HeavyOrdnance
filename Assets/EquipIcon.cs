using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipIcon : MonoBehaviour
{
    private EquipmentSlotInfo equipmentSlot;
    private RawImage eqpIcon;
    void Start()
    {
        eqpIcon = gameObject.GetComponent<RawImage>();
        eqpIcon.enabled = false;
        PartButton buttonInfo = gameObject.GetComponentInParent<PartButton>();
        equipmentSlot = buttonInfo.equipmentSlotInfo;
        UpdateEquipIcon();
    }


    public void UpdateEquipIcon()
    {
        eqpIcon.enabled = false;

        if (equipmentSlot.partType.Equals(EquipmentSlotInfo.PartType.Turret))
        {

            if (PlayerProgress.turretInfo == null)
            {
                return;
            }
            if (equipmentSlot.turretStats == PlayerProgress.turretInfo)
            {
                eqpIcon.enabled = true;
            }
            return;
        }
        if (equipmentSlot.partType.Equals(EquipmentSlotInfo.PartType.Armor))
        {

            if (PlayerProgress.bodyInfo == null)
            {
                return;
            }
            if (equipmentSlot.bodyStats == PlayerProgress.bodyInfo)
            {

                eqpIcon.enabled = true;
            }
            return;
        }
        if (equipmentSlot.partType.Equals(EquipmentSlotInfo.PartType.Track))
        {
            if (PlayerProgress.trackInfo == null)
            {
                return;
            }
            if (equipmentSlot.trackStats == PlayerProgress.trackInfo)
            {
                eqpIcon.enabled = true;
            }
            return;
        }


    }

    private void OnEnable()
    {
        PlayerSelection.onConfirmEquip += UpdateEquipIcon;
    }

    private void OnDisable()
    {
        PlayerSelection.onConfirmEquip -= UpdateEquipIcon;
    }
}
