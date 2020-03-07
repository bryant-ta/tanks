﻿using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Damageable
{
    public float hpRegen;

    Image hpBar;
    Text hpTxt;

    private void Start()
    {
        Setup();
        hpBar = GameObject.Find("HPBar").GetComponent<Image>();
        hpTxt = GameObject.Find("HPTxt").GetComponent<Text>();

        UpdateHP();
    }

    //float startRegen;
    private void Update()
    {
        // HP Regen
        int regenAmt = (int)(getMaxHP() * (hpRegen / 100));
        AddHP(regenAmt);
    }

    public new bool DoDamage(int amt)
    {
        bool ret = base.DoDamage(amt);
        UpdateHP();
        return ret;
    }

    public void UpdateHP()
    {
        hpBar.fillAmount = ((float)getHP() / (float)getMaxHP());
        hpTxt.text = getHP() + "/" + getMaxHP();
    }
}
