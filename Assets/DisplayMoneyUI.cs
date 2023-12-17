using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMoneyUI : MonoBehaviour
{

    public Text moneyText;
    // Start is called before the first frame update
    void Start()
    {
        moneyText.text = "$" + PlayerProgress.money.ToString();
    }

    //lazy version
    void LateUpdate()
    {
        moneyText.text = "$" + PlayerProgress.money.ToString();
    }

}
