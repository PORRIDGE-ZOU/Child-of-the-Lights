using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Security.Cryptography;
using JetBrains.Annotations;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using UnityEngine.Analytics;
using UnityEngine.Tilemaps;

public class BulletColoring : MonoBehaviour
{
    // Start is called before the first frame update
    private BulletTag bulletTag;
    void Start()
    {

        bulletTag = GetComponent<BulletTag>();

    }

    // Update is called once per frame
    void Update()
    {
        Color();
    }

    private void Color()
    {

        foreach (ColorTag.Colors color in Enum.GetValues(typeof(ColorTag.Colors)))
        {
            //Do nothing on Black (To avoid bugs on Input.GetButtonDown)
            if (color.Equals(ColorTag.Colors.Black) || color.Equals(ColorTag.Colors.White)) continue;

            String coloring = color.ToString() + "_Bullet";
            // Debug.Log(coloring);
            if (Input.GetButtonDown(coloring))
            {
                //Debug.Log("Hello!");
                bulletTag.color = color;
                Debug.Log(bulletTag.color.ToString());
                //WE SHOULD BREAK HERE SHALL WE 
                //for performance
                break;
            }
        }

    }
}
