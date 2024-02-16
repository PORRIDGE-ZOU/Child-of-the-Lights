using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBulletCollision : MonoBehaviour
{

	// Start is called before the first frame update

	//colorTag is the color of this wall
	private ColorTag colorTag;
	private GameObject player;
	private SpriteChanger spriteChanger;

	void Start()
	{
		colorTag = GetComponent<ColorTag>();
		player = GameObject.FindWithTag("Yaowan");
		spriteChanger = GetComponent<SpriteChanger>();
	}



	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag("Bullet"))
		{
			Debug.Log("Detected!");
			BulletTag bulletTag = GameObject.FindObjectOfType<BulletTag>();
			//BulletTag bulletTag = player.GetComponent<BulletTag>();
			colorTag.colors = bulletTag.color;
			if (PlayerFiltering.currentFilter.Equals(bulletTag.color))
			{
				//so that this wall, on coloring, shall be filtered out. so we need to refresh to colliders.
				PlayerFiltering.ToggleColorColliders(bulletTag.color);
			}
			if (spriteChanger != null)
			{
				spriteChanger.ColorTagChange();
			}
			// CanFire fire = player.GetComponent<CanFire>();
			// if (bulletTag.color == ColorTag.Colors.Red)
			// {
			// 	fire.Red--;
			// 	Debug.Log(fire.Red);
			// }
			// if (bulletTag.color == ColorTag.Colors.Blue)
			// {
			// 	fire.Blue--;
			// 	Debug.Log(fire.Blue);
			// }
			// if (bulletTag.color == ColorTag.Colors.Green)
			// {
			// 	fire.Green--;
			// 	Debug.Log(fire.Green);
			// }
		}
	}
}
