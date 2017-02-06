using UnityEngine;
using System.Collections;

public class enemyBase : MonoBehaviour
{

	public void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.name == "Hero")
		{
			enemy.agro = true;
		}
	}
}
