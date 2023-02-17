// Bashier Dahman
// CharacterClass.cs that will be used as my character object
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClass : MonoBehaviour
{
    // creating the singleton object of CharacterClass
    private static CharacterClass instance;

    public static CharacterClass Instance { get { return instance;  } }

    public void Awake()  {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else  {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }

    }
    // all attributes that the CharacterClass will have 
    public string Race;
    public string Class;
    public string Alignment;
    public string CharName;

    public int Strength;
    public int Dexterity;
    public int Constitution;
    public int Intelligence;
    public int Wisdom;
    public int Charisma;

    public int CurrentXP;
    public int MaxXP;
    public int CurrentHP;
    public int MaxHP;
    public int ArmorClass;
    public int WalkSpeed;
    public int RunSpeed;
    public int JumpHeight;

    public List<string> Items;

    // function to output the JSON String of the Character Object
    public string JSONOutput()
    {
        return JsonUtility.ToJson(this);
    }

}
