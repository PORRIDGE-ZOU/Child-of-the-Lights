using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using MoreMountains.CorgiEngine;
using UnityEngine;

public class ColorCollisionCheck : MonoBehaviour
{

    [SerializeField] PlayerFiltering playerFiltering;

    private void OnTriggerEnter2D(Collider2D other)
    {
        ColorTag colorTag = other.GetComponent<ColorTag>();
        if (colorTag != null)
        {
            switch (colorTag.colors)
            {
                case ColorTag.Colors.Red:
                    playerFiltering.inRed = true;
                    break;
                case ColorTag.Colors.Blue:
                    playerFiltering.inBlue = true;
                    break;
                case ColorTag.Colors.Green:
                    playerFiltering.inGreen = true;
                    break;
                case ColorTag.Colors.Yellow:
                    playerFiltering.inYellow = true;
                    break;
                default:
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        ColorTag colorTag = other.GetComponent<ColorTag>();
        if (colorTag != null)
        {
            switch (colorTag.colors)
            {
                case ColorTag.Colors.Red:
                    playerFiltering.inRed = false;
                    break;
                case ColorTag.Colors.Blue:
                    playerFiltering.inBlue = false;
                    break;
                case ColorTag.Colors.Green:
                    playerFiltering.inGreen = false;
                    break;
                case ColorTag.Colors.Yellow:
                    playerFiltering.inYellow = false;
                    break;
                default:
                    break;
            }
        }

    }

}
