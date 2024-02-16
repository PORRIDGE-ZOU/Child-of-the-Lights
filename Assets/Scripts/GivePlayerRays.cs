using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;

public class GivePlayerRays : AIAction
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public GameObject Player;


    public GenieColor genieColor;
    public int number;

    public void GiveRays()
    {
        CanFire[] canFires = FindObjectsOfType<CanFire>();
        CanFire canFire = canFires[0];
        switch (genieColor.color)
        {
            case ColorTag.Colors.Red:
                canFire.Red += number;
                break;
            case ColorTag.Colors.Blue:
                canFire.Blue += number;
                break;
            case ColorTag.Colors.Green:
                canFire.Green += number;
                break;
            case ColorTag.Colors.Yellow:
                canFire.Yellow += number;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void PerformAction()
    {

    }

    public override void OnEnterState()
    {
        base.OnEnterState();
        GiveRays();
        return;
    }

    public override void OnExitState()
    {
        base.OnExitState();
        return;
    }
}
