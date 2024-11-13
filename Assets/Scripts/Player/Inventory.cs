using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public weaponType     playerWeapon;
    [Header("Dynamic")]
    public int            jewels = 0;
    public TMP_Text       jewelText;
    public TMP_Text       HPText;
    static public         Inventory I;
    public elementTypes[] playerElements;
    public int playerWandLevel = 1;
    public Dictionary<elementTypes, int> playerElementLevels = new Dictionary<elementTypes, int>();
    
    // int bc not expected to ever have more than one wand, easy change to dict if ever changed

    // Start is called before the first frame update
    void Start()
    {
        I = this;

        // will be set by weapon choosing screen
        playerWeapon    = weaponType.singleElementFocusWand;
        WandDefinition playerWandDef = Main.GET_WAND_DEFINITION(playerWeapon);
        playerElements = weapon.w.eleTypes = new elementTypes[playerWandDef.maxElementTypes];
        for (int i = 0; i < playerElements.Length; i++) {
            playerElements[i] = elementTypes.None;
            weapon.w.eleTypes[i]  = playerElements[i];
            Debug.Log(playerElements[i]);
        }
        weapon.w.type     = playerWeapon;   


        foreach(elementTypes ele in playerElements) {
            elementLevelUp(ele, 0);
        }
    }

    public void UpdateCurrency() 
    {
        jewelText.SetText(jewels.ToString("0"));
    }
    public void UpdateHealth(float currentPlayerHealth) 
    {
        currentPlayerHealth = (int)currentPlayerHealth;
        HPText.SetText(currentPlayerHealth.ToString("00"));
        
    }

    public void elementLevelUp(elementTypes elementToLevel, int amount) 
    {
        // add desired level to desired element if exists, else add it to the dictionary
        if (playerElementLevels.ContainsKey(elementToLevel)) {
            playerElementLevels[elementToLevel] += amount;
        }
        else {
            playerElementLevels.Add(elementToLevel, amount);
        }
    }
    public void wandLevelUp(int level) 
    {
        playerWandLevel += level;
    }
}
