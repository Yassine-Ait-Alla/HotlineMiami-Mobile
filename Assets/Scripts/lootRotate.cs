using UnityEngine;
using System.Collections;

public class lootRotate : MonoBehaviour
{
	void Update ()
	{
		transform.Rotate(Vector3.forward * Time.deltaTime * 50);
	}
}
