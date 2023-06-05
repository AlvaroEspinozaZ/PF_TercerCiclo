using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class Abilities : MonoBehaviour
{
    [Header("Ability1")]
    public Image abilityImage1;
    public float cooldown1 = 1.5f;
    public bool isCooldown1 = false;
    public bool doIt1 = false;
    [Header("Ability2")]
    public Image abilityImage2;
    public float cooldown2 = 1;
    public bool isCooldown2 = false;
    public bool doIt2 = false;
    [Header("Ability2")]
    public Image abilityImage3;
    public float cooldown3 = 5;
    public bool isCooldown3 = false;
    public bool doIt3 = false;
    void Start()
    {
        abilityImage1.fillAmount = 0;
        abilityImage2.fillAmount = 0;
        abilityImage3.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Ability1(doIt1);
        Ability2(doIt2);
        Ability3(doIt3);
    }
    public void Ability1(bool itDidIt)
    {
        if(itDidIt && isCooldown1 == false)
        {
            isCooldown1 = true;
            doIt1 = false;
            abilityImage1.fillAmount = 1;
        }
        if (isCooldown1)
        {
            abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;
            if (abilityImage1.fillAmount <= 0)
            {

                abilityImage1.fillAmount = 0;
                isCooldown1 = false;
            }
        }
    }
    public void Ability2(bool itDidIt)
    {
        if (itDidIt && isCooldown2 == false)
        {
            isCooldown2 = true;
            doIt2 = false;
            abilityImage2.fillAmount = 1;
        }
        if (isCooldown2)
        {
            abilityImage2.fillAmount -= 1 / cooldown2 * Time.deltaTime;
            if (abilityImage2.fillAmount <= 0)
            {

                abilityImage2.fillAmount = 0;
                isCooldown2 = false;
            }
        }

    }
    public void Ability3(bool itDidIt)
    {
        if (itDidIt && isCooldown3 == false)
        {
            isCooldown3 = true;
            doIt3 = false;
            abilityImage3.fillAmount = 1;
        }
        if (isCooldown3)
        {
            abilityImage3.fillAmount -= 1 / cooldown3 * Time.deltaTime;
            if (abilityImage3.fillAmount <= 0)
            {

                abilityImage3.fillAmount = 0;
                isCooldown3 = false;
            }
        }
    }
}
