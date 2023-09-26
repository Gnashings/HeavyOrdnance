using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityDictionary : MonoBehaviour
{
    public Text title;
    public Text defText;
    public Text spcText;
    [System.Serializable]
    public class Abilities
    {
        public string Name;
        public string Def;
        public string SpecialEffect;
    }
    public List<Abilities> abilities;
    public Dictionary<string, string> ability;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InvokeDefinition(string tag)
    {
        foreach(Abilities ability in abilities)
        {
            if(tag.Equals(ability.Name))
            {
                title.text = ability.Name;
                defText.text = ability.Def;
                spcText.text = ability.SpecialEffect;
            }
        }
    }
}
