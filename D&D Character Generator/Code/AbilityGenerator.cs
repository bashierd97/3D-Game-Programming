// Bashier Dahman
// Ability Generator
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityGenerator : MonoBehaviour {

    // All variables I will be using
    public Text StrengthBox;
    public Text DexterityBox;
    public Text ConstitutionBox;
    public Text IntelligenceBox;
    public Text WisdomBox;
    public Text CharismaBox;

    public int sum6;
    public int sum4;
    public int totalSum;
    
    // creating two array lists to hold the numbers for 6 sided die roll and 3 sided die roll
    ArrayList num6List = new ArrayList();
    ArrayList num4List = new ArrayList();

    // function to roll dice
    public int RandomDiceNumber() {

        // clear the array lists so another button can run this
        num6List.Clear();
        num4List.Clear();

        // reset all sum variables to 0
        sum6 = 0;
        sum4 = 0;
        totalSum = 0;

        num6List.Add(Random.Range(1, 7));
        num6List.Add(Random.Range(1, 7));
        num6List.Add(Random.Range(1, 7));

        num4List.Add(Random.Range(1, 5));
        num4List.Add(Random.Range(1, 5));
        num4List.Add(Random.Range(1, 5));

        // sort both the array lists from smallest to greatest
        num6List.Sort();
        num4List.Sort();

        // remove smallest numbers from each array list
        num6List.RemoveAt(0);
        num4List.RemoveAt(0);

        // add both numbers in array list for 6 sided die
        foreach (int n in num6List) {
            sum6 = sum6 + n;
        }

        // add both numbers in array list for 3 sided die
        foreach (int z in num4List)  {
            sum4 = sum4 + z;
        }

        // add sum6 and sum4 to get total sum
        totalSum = sum6 + sum4;

        // add the +2 for the default modifier 
        totalSum += 2;

        return totalSum;
    }

    public void RollStrength()
    {
        int strength_val = RandomDiceNumber();
        // output the total sum to the text box
        StrengthBox.text = strength_val.ToString();
        CharacterClass.Instance.Strength = strength_val;
    }

    public void RollDexterity()
    {
        int dexterity_val = RandomDiceNumber();
        // output the total sum to the text box
        DexterityBox.text = dexterity_val.ToString();
        CharacterClass.Instance.Dexterity = dexterity_val;
    }

    public void RollConstituition()
    {
        int constitution_val = RandomDiceNumber();
        // output the total sum to the text box
        ConstitutionBox.text = constitution_val.ToString();
        CharacterClass.Instance.Constitution = constitution_val;
    }

    public void RollIntelligence()
    {
        int intelligence_val = RandomDiceNumber();
        // output the total sum to the text box
        IntelligenceBox.text = intelligence_val.ToString();
        CharacterClass.Instance.Intelligence = intelligence_val;
    }

    public void RollWisdom()
    {
        int wisdom_val = RandomDiceNumber();
        // output the total sum to the text box
        WisdomBox.text = wisdom_val.ToString();
        CharacterClass.Instance.Wisdom = wisdom_val;
    }

    public void RollCharisma()
    {
        int charisma_val = RandomDiceNumber();
        // output the total sum to the text box
        CharismaBox.text = charisma_val.ToString();
        CharacterClass.Instance.Charisma = charisma_val;
    }
}

