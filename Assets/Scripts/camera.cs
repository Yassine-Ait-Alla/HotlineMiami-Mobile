using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour
{
	void Update () 
	{
		if (player.life > 1)
			transform.position = new Vector3 (player.pp.position.x, player.pp.position.y, -10);
	}
}
