using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using UnityEngine;

public class DestroyWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public Weapon weapon;

    // Update is called once per frame
    void Update()
    {
        if (weapon.CurrentAmmoLoaded == 0)
        {
            weapon.gameObject.SetActive(false);
        }
    }
}
