// Bashier Dahman
// InputFieldScript.cs
// Project 1
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InputFieldScript : MonoBehaviour {

    // reference for input field for the char name
    public InputField inputName;

    // references for all the other input fields
    public InputField cur_XP;
    public InputField max_XP;
    public InputField cur_HP;
    public InputField max_HP;
    public InputField armor_Class;
    public InputField walk_Speed;
    public InputField run_Speed;
    public InputField jump_Height;

    // methods for taking the values from the input fields
    public void enter_name(string name)
    {
        CharacterClass.Instance.CharName = name;
    }

    public void cXP(string curXP)
    {
        int cXP_int = Int32.Parse(curXP);
        CharacterClass.Instance.CurrentXP = cXP_int;
    }
    public void mXP(string maxXP)
    {
        int mXP_int = Int32.Parse(maxXP);
        CharacterClass.Instance.MaxXP = mXP_int;
    }
    public void cHP(string curHP)
    {
        int cHP_int = Int32.Parse(curHP);
        CharacterClass.Instance.CurrentHP = cHP_int;
    }
    public void mHP(string maxHP)
    {
        int mHP_int = Int32.Parse(maxHP);
        CharacterClass.Instance.MaxHP = mHP_int;
    }

    public void armClass(string armor)
    {
        int arm_int = Int32.Parse(armor);
        CharacterClass.Instance.ArmorClass = arm_int;
    }
    public void wSpeed(string ws)
    {
        int ws_int = Int32.Parse(ws);
        CharacterClass.Instance.WalkSpeed = ws_int;
    }
    public void rSpeed(string rs)
    {
        int rs_int = Int32.Parse(rs);
        CharacterClass.Instance.RunSpeed = rs_int;
    }
    public void jHeight(string jh)
    {
        int jh_int = Int32.Parse(jh);
        CharacterClass.Instance.JumpHeight = jh_int;
    }


}
