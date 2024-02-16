using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletUI : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject player;
    private ColorTag colorTag;
    BulletTag bulletTag;
    Image img;
    void Start()
    {
        player = GameObject.FindWithTag("Yaowan");
        img = gameObject.GetComponent<Image>();
        colorTag = gameObject.GetComponent<ColorTag>();
        bulletTag = player.GetComponent<BulletTag>();
    }

    // Update is called once per frame
    void Update()
    {
        if (colorTag != null && bulletTag.color == colorTag.colors)
        {

            if (img != null)
            {
                img.enabled = true;
            }

        }
        else
        {
            if (img != null) img.enabled = false;
        }
    }
}
