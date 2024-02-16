using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BulletNumberUI : MonoBehaviour
{

    private GameObject player;
    private TMP_Text mytext;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Yaowan");
        mytext = GetComponent<TMP_Text>();

    }

    // Update is called once per frame
    void Update()
    {
        BulletTag bulletTag = player.GetComponent<BulletTag>();
        CanFire canfire = player.GetComponent<CanFire>();
        if (bulletTag.color == ColorTag.Colors.Red)
        {
            mytext.text = canfire.Red.ToString();
            mytext.color = new Color(228f/255f,114f/255f,118f/255f,255f/255f);
        }

        if (bulletTag.color == ColorTag.Colors.Green)
        {
            mytext.text = canfire.Green.ToString();
            mytext.color = new Color(135f/255f,217f/255f,212f/255f,243f/255f);
        }

        if (bulletTag.color == ColorTag.Colors.Blue)
        {
            mytext.text = canfire.Blue.ToString();

            mytext.color = new Color(132f / 255f, 191f / 255f, 235f / 255f, 255f / 255f);
        }

        if (bulletTag.color == ColorTag.Colors.Yellow)
        {
            mytext.text = canfire.Yellow.ToString();
            mytext.color = new Color(250f/255f,198f/255f,137f/255f,255f/255f);
        }



    

    }
}
