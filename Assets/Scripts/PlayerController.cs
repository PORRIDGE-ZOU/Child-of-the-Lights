using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpSpeed;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool isGrounded;
    private Rigidbody2D myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            myRigidbody.velocity = new Vector3(moveSpeed, myRigidbody.velocity.y, 0f);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0f);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0f);
            Debug.Log("Hello!");
        }
        // if (Input.GetButtonDown("Red_Filter"))
        // {
        //     DisableRedColliders();
        // }
    }
    private void DisableRedColliders()
    {
        ColorTag[] allColorTags = FindObjectsOfType<ColorTag>();
        foreach (ColorTag tag in allColorTags)
        {
            if (tag.colors.Equals(ColorTag.Colors.Red))
            {
                BoxCollider2D collider = tag.GetComponent<BoxCollider2D>();
                if (collider != null)
                {
                    collider.enabled = false;
                }
            }
        }
    }
}
