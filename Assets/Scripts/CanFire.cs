using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.CorgiEngine;

public class CanFire : MonoBehaviour
{

    public int Red;
    public int Blue;
    public int Green;
    public int Yellow;
    private CharacterHandleWeapon weaponHandle;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        weaponHandle = GetComponent<CharacterHandleWeapon>();
        player = GameObject.FindWithTag("Yaowan");

    }

    // Update is called once per frame
    void Update()
    {
        BulletTag bulletTag = player.GetComponent<BulletTag>();
        if (Input.GetButtonDown("Player1_Shoot"))
        {
            switch (bulletTag.color)
            {
                case ColorTag.Colors.Red:

                    if (Red > 0) Red--;
                    break;
                case ColorTag.Colors.Blue:
                    if (Blue > 0) Blue--;
                    break;
                case ColorTag.Colors.Green:
                    if (Green > 0) Green--;
                    break;


                case ColorTag.Colors.Yellow:
                    if (Yellow > 0) Yellow--;
                    break;

                default:
                    break;
            }
        }
        if (bulletTag.color == ColorTag.Colors.Red)
        {
            if (Red <= 0)
            {
                weaponHandle.enabled = false;
            }
            else
            {
                weaponHandle.enabled = true;
            }
        }

        if (bulletTag.color == ColorTag.Colors.Green)
        {
            if (Green <= 0)
            {
                weaponHandle.enabled = false;
            }
            else
            {
                weaponHandle.enabled = true;
            }

        }

        if (bulletTag.color == ColorTag.Colors.Blue)
        {
            if (Blue <= 0)
            {
                weaponHandle.enabled = false;
            }
            else
            {
                weaponHandle.enabled = true;
            }
        }


        if (bulletTag.color == ColorTag.Colors.Yellow)
        {
            if (Yellow <= 0)
            {
                weaponHandle.enabled = false;
            }
            else
            {
                weaponHandle.enabled = true;
            }
        }
    }


}
