using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpriteChanger : MonoBehaviour
{

    public RuleTile greenTile;
    public RuleTile redTile;
    public RuleTile blueTile;

    public RuleTile yellowTile;
    private ColorTag colorTag;
    private Tilemap tilemap;
    // Start is called before the first frame update
    void Start()
    {
        colorTag = GetComponent<ColorTag>();
        tilemap = GetComponent<Tilemap>();

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ColorTagChange()
    {
        if (colorTag.colors == ColorTag.Colors.Green)
        {
            ChangeTiles(greenTile);
        }
        else if (colorTag.colors == ColorTag.Colors.Red)
        {
            ChangeTiles(redTile);
        }
        else if (colorTag.colors == ColorTag.Colors.Blue)
        {
            ChangeTiles(blueTile);
        }
        else if (colorTag.colors == ColorTag.Colors.Yellow)
        {
            ChangeTiles(yellowTile);
        }
    }

    public void ChangeTiles(RuleTile newTile)
    {
        for (int n = tilemap.cellBounds.xMin; n < tilemap.cellBounds.xMax; n++)
        {
            for (int p = tilemap.cellBounds.yMin; p < tilemap.cellBounds.yMax; p++)
            {
                Vector3Int position = new Vector3Int(n, p, 0);
                if (tilemap.HasTile(position))
                {
                    tilemap.SetTile(position, newTile);
                }
            }
        }
    }
}
