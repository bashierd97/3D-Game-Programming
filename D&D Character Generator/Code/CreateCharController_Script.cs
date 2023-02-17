// Bashier Dahman
// Project 1
// Create Character Controller Script
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CreateCharController_Script : MonoBehaviour {

    // all dropdown menus I reference
    public Dropdown dropdownRace;
    public Dropdown dropdownClass;
    public Dropdown dropdownAlignment;

    // all input fields I reference
    public InputField outputBox;
    public InputField jsonBox;

    // lists of drop down menu selections 
    private List<string> raceList = new List<string>() { "Choose Race", "Dragonborn", "Dwarf", "Elf", "Gnome", "Half-Elf", "Half-Orc", "Halfling", "Human", "Tiefling" };
    private List<string> classList = new List<string>() { "Choose Class", "Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", "Paladin", "Ranger", "Rogue", "Sorcerer", "Warlock", "Wizard" };
    private List<string> alignmentList = new List<string>() { "Choose Alignment", "Lawful Good", "Neutral Good", "Chaotic Good", "Lawful Neutral", "Neutral", "Chaotic Neutral", "Lawful Evil", "Neutral Evil", "Chaotic Evil" };

    // start function to populate lists and have my output boxes as read only
    // (no edit, can only copy values)
    void Start()   {
        PopulateRaceList();
        PopulateClassList();
        PopulateAlignmentList();
        outputBox.readOnly = true;
        jsonBox.readOnly = true;
    }

    /////// POPULATE DROP DOWN BOXES ///////
    void PopulateRaceList()   {
        dropdownRace.AddOptions(raceList);
       
    }

    void PopulateClassList()   {
        dropdownClass.AddOptions(classList);

    }

    void PopulateAlignmentList()   {
        dropdownAlignment.AddOptions(alignmentList);

    }
    /////// POPULATE DROP DOWN BOXES ///////
    
    ////// these following functions are used to change /////////
    // the race / class / alignment of my character instance
    public void change_race(int raceIndex) {
        // little error handling to make sure the "Choose Race(or class / alignment)"
        // option isnt selected
        if (raceIndex != 0)  {
            CharacterClass.Instance.Race = raceList[raceIndex];

        }
        else  {
            // just print out an error message to the console 
            Debug.Log("Please select a valid race");
        }
    }
    public void change_class(int classIndex)  {
        if (classIndex != 0)  {
            CharacterClass.Instance.Class = classList[classIndex];
        }
        else  {
            Debug.Log("Please select a valid class");
        }
    }

    public void change_alignment(int alignmentIndex)  {
        if (alignmentIndex != 0)   {
            CharacterClass.Instance.Alignment = alignmentList[alignmentIndex];
        }
        else   {
            Debug.Log("Please select a valid alignment");
        }
    }
    ////////////////////////////////////////////////////
    
    ////// This function will be used by the "generate character"
    /// button and display all valuable stats and info to the output boxes
    public void Enter_Button()   {
        // receive race and class from instance
        string race_statement = CharacterClass.Instance.Race;
        string class_statement = CharacterClass.Instance.Class;
        
        // output all text to output box
        outputBox.text = "Character Name: " + CharacterClass.Instance.CharName + " Race: " + CharacterClass.Instance.Race + " Class: " + CharacterClass.Instance.Class + " Alignment: " + CharacterClass.Instance.Alignment
            + "\nStrength: " + CharacterClass.Instance.Strength + " Dexterity: " + CharacterClass.Instance.Dexterity + " Constitution: " + CharacterClass.Instance.Constitution + " Intelligence: " + CharacterClass.Instance.Intelligence
            + " Wisdom: " + CharacterClass.Instance.Wisdom + " Charisma: " + CharacterClass.Instance.Charisma
            + "\nCurrent XP: " + CharacterClass.Instance.CurrentXP + " Max XP: " + CharacterClass.Instance.MaxXP + " Current HP: " + CharacterClass.Instance.CurrentHP
            + " Max HP: " + CharacterClass.Instance.MaxHP + " Armor Class: " + CharacterClass.Instance.ArmorClass + " Walking Speed: " + CharacterClass.Instance.WalkSpeed
            + " Running Speed: " + CharacterClass.Instance.RunSpeed + " Jump Height: " + CharacterClass.Instance.JumpHeight + "\n"
            + "\nRace Summary: " + Race_Summary(race_statement)
            + "\nClass Summary: " + Class_Summary(class_statement);

        // output JSON string to JSON box
        PlayerPrefs.SetString("JSONOutput", CharacterClass.Instance.JSONOutput());
        jsonBox.text = CharacterClass.Instance.JSONOutput();
    }

    // function used to display race summary
    public string Race_Summary(string race)  {
        switch (race)   {
            case "Dragonborn":
                return "Your draconic heritage manifests in a variety of traits you share with other dragonborn";
            case "Dwarf":
                return "Your dwarf character has an assortment of in abilities, part and parcel of dwarven nature";
            case "Elf":
                return "Your elf character has a variety of natural abilities, the result of thousands of years of elven refinement.";
            case "Gnome":
                return "Your gnome character has certain characteristics in common with all other gnomes.";
            case "Half-Elf":
                return "Your half - elf character has some qualities in common with elves and some that are unique to half-elves.";
            case "Half-Orc":
                return "Your half-orc character has certain traits deriving from your orc ancestry.";
            case "Halfling":
                return "Your halfling character has a number of traits in common with all other halflings.";
            case "Human":
                return "It's hard to make generalizations about humans, but your human character has these traits.";
            case "Tiefling":
                return "Tieflings share certain racial traits as a result of their infernal descent";
            default:
                return "You didn't select a race";
        }
    }

    // function to display class summary
    public string Class_Summary(string class_sum)
    {
        switch (class_sum)
        {
            case "Barbarian":
                return "In battle, you fight with primal ferocity. For some barbarians, rage is a means to an end–that end being violence.";
            case "Bard":
                return "Whether singing folk ballads in taverns or elaborate compositions in royal courts, bards use their gifts to hold audiences spellbound.";
            case "Cleric":
                return "Clerics act as conduits of divine power.";
            case "Druid":
                return "Druids venerate the forces of nature themselves. Druids holds certain plants and animals to be sacred, and most druids are devoted to one of the many nature deities.";
            case "Fighter":
                return "Different fighters choose different approaches to perfecting their fighting prowess, but they all end up perfecting it.";
            case "Monk":
                return "Coming from monasteries, monks are masters of martial arts combat and meditators with the ki living forces.";
            case "Paladin":
                return "Paladins are the ideal of the knight in shining armor; they uphold ideals of justice, virtue, and order and use righteous might to meet their ends.";
            case "Ranger":
                return "Acting as a bulwark between civilization and the terrors of the wilderness, rangers study, track, and hunt their favored enemies.";
            case "Rogue":
                return "Rogues have many features in common, including their emphasis on perfecting their skills, their precise and deadly approach to combat, and their increasingly quick reflexes.";
            case "Sorcerer":
                return "An event in your past, or in the life of a parent or ancestor, left an indelible mark on you, infusing you with arcane magic.As a sorcerer the power of your magic relies on your ability to project your will into the world.";
            case "Warlock":
                return "You struck a bargain with an otherworldly being of your choice: the Archfey, the Fiend, or the Great Old One who has imbued you with mystical powers, granted you knowledge of occult lore, bestowed arcane research and magic on you and thus has given you facility with spells.";
            case "Wizard":
                return "The study of wizardry is ancient, stretching back to the earliest mortal discoveries of magic. As a student of arcane magic, you have a spellbook containing spells that show glimmerings of your true power which is a catalyst for your mastery over certain spells.";
            default:
                return "You didn't select a class";
        }
    }
}
