using UnityEngine;
using System.Collections;

public class enemyBase : MonoBehaviour
{

	public void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.name == "rambo")
		{
			enemy.agro = true;
		}
	}
}
