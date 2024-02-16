using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using JetBrains.Annotations;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Tilemaps;

public class PlayerFiltering : MonoBehaviour
{

    public static ColorTag.Colors currentFilter;

    public Transform groundCheck;

    public LayerMask whatIsGround;

    public bool isGrounded;

    bool canFilter = true;

    public bool inRed = false, inGreen = false, inBlue = false, inYellow = false;

    Character character = null;

    void Start()
    {
        //TODO: Enable all colliders upon respawn;
        //we should NOT set them here, this does not work. we should use scene manager.
        currentFilter = ColorTag.Colors.White;
        character = GetComponent<Character>();

    }

    //OnCollision seems not working, because our player.isTrigger is true; under which circumstance we can only use OnTrigger.
    private void OnCollisionStay2D(Collision2D other)
    {
        //attempting to cancel filtering while passing through any platforms...
        // Debug.Log("well, entering" + other.ToString());
        // if (other.collider.CompareTag("Platforms"))
        // {

        //     Debug.Log("disabling...");
        //     canFilter = false;
        // }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        // if (other.collider.CompareTag("Platforms"))
        // {
        //     canFilter = true;
        // }
    }

    //this ALWAYS triggers, whenever we're touching upon anything. because we are a trigger.
    //Which makes it harder to tell if we are actually "passing through" something.
    private void OnTriggerStay2D(Collider2D other) { }
    bool IsPassingThroughPlatform()
    {

        RaycastHit2D hit = MMDebug.RayCast(transform.position, Vector2.up, Mathf.Infinity, LayerManager.PlatformsLayerMask, Color.gray);
        Debug.Log(hit.collider == null);
        if (hit.collider != null)
        {
            Debug.Log("hit, distance is " + hit.distance);
            // Check if the platform is close enough to be considered as 'passing through'
            //the problem here is: by using collider.enabled = false; we actually SET IT TO NULL!!!
            return hit.distance < float.MinValue * 2;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {

        Filter();



        // double groundCheckRadius=GetComponent<BoxCollider2D>().size.y/2;
        Vector2 size = new Vector2(GetComponent<BoxCollider2D>().size.x - 0.5f, GetComponent<BoxCollider2D>().size.y - 0.5f);

        // float myDouble =(float)groundCheckRadius;
        // canFilter = Physics2D.OverlapCircle(groundCheck.position, size, 0f, whatIsGround);

        canFilter = Physics2D.OverlapBox(groundCheck.position, size, 0f, whatIsGround);
        //THIS is very complicated. Harder than I thought.
        // if (IsPassingThroughPlatform())
        // {
        //     Debug.Log("Hello!");
        //     canFilter = false;
        // }
        if (canFilter == true)
        {
            KillPlayer();
        }
    }

    public void KillPlayer()
    {
        if (character != null)
        {
            if (character.ConditionState.CurrentState != CharacterStates.CharacterConditions.Dead)
            {
                character.CharacterHealth.Kill();
            }
        }
    }

    private void Filter()
    {
        foreach (ColorTag.Colors color in Enum.GetValues(typeof(ColorTag.Colors)))
        {
            //Do nothing on Black (To avoid bugs on Input.GetButtonDown)
            if (color == ColorTag.Colors.Black) continue;

            String filter = color.ToString() + "_Filter";
            if (Input.GetButtonDown(filter))
            {
                currentFilter = color;
                //bool isInOtherColor = isInAnotherColor(color);
                //Debug.Log("red: " + inRed + " blue:" + inBlue + " green: " + inGreen + " yellow:" + inYellow);
                //if (isInOtherColor) KillPlayer();
                ToggleColorColliders(color);

                break;
            }
        }

        foreach (BackgroundTag.Colors bgcolor in Enum.GetValues(typeof(BackgroundTag.Colors)))
        {
            //Do nothing on Black (To avoid bugs on Input.GetButtonDown)
            if (bgcolor == BackgroundTag.Colors.Black) continue;

            String filter = bgcolor.ToString() + "_Filter";
            if (Input.GetButtonDown(filter))
            {

                ToggleBGColorColliders(bgcolor);
                //WE SHOULD BREAK HERE SHALL WE 
                //for performance
                break;
            }
        }
    }

    public static void ToggleColorColliders(ColorTag.Colors color)
    {
        ColorTag[] allColorTags = FindObjectsOfType<ColorTag>();
        foreach (ColorTag tag in allColorTags)
        {
            //skip over Black
            if (color.Equals(ColorTag.Colors.Black)) continue;

            TilemapCollider2D collider = tag.GetComponent<TilemapCollider2D>();
            if (collider != null)
            {
                if (tag.colors.Equals(color))
                {
                    //it seems that they just used enabled = false to implement this NoCollision layer... shit!
                    //tag.gameObject.layer = LayerMask.NameToLayer("NoCollision");

                    //isTrigger is also not working. This may be due to our collision is actually controlled by the Corgi Engine, not Unity, so changing isTrigger here does not work...
                    //collider.isTrigger = true;
                    collider.enabled = false;
                }
                else
                {
                    //tag.gameObject.layer = LayerMask.NameToLayer("Platforms");
                    //collider.isTrigger = false;
                    collider.enabled = true;
                }
            }

            //Debug.Log("tag's current collider: " + tag + collider.enabled);

        }
    }

    private void ToggleBGColorColliders(BackgroundTag.Colors color)
    {
        BackgroundTag[] allColorTags = FindObjectsOfType<BackgroundTag>();
        foreach (BackgroundTag tag in allColorTags)
        {
            //skip over Black
            if (color.Equals(BackgroundTag.Colors.Black)) continue;
            if (tag.GetComponent<Canvas>() != null)
            {
                if (tag.colors.Equals(color))
                {
                    tag.GetComponent<Canvas>().sortingOrder = -99;
                }
                else
                {
                    tag.GetComponent<Canvas>().sortingOrder = -101;

                }
            }

        }
    }

    private bool isInAnotherColor(ColorTag.Colors color)
    {
        switch (color)
        {
            case ColorTag.Colors.Red:
                return inYellow || inBlue || inGreen;
            case ColorTag.Colors.Green:
                return inYellow || inBlue || inRed;
            case ColorTag.Colors.Blue:
                return inYellow || inRed || inGreen;
            case ColorTag.Colors.Yellow:
                return inRed || inBlue || inGreen;
            default:
                return false;
        }
    }
}
