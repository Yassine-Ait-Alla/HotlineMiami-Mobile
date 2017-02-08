using UnityEngine;
using System.Collections;

public class badBullet : MonoBehaviour {

	public Vector3				target;
	//public AudioSource	son;

	void Start ()
	{
		target = player.pp.position;
	}

	void Update ()
	{

		//Vector3 target;
		//target = player.pp.position;

		Vector3 dir = target - transform.position;

		/*
		float		y = dir.y;
		float		x = dir.x;
		Debug.Log("X = " + x + " Y = " + y);
		*/

		float	angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		transform.Translate(Vector3.right * Time.deltaTime * 7);
	}

	public void		OnCollisionEnter2D(Collision2D col)
	{
		Destroy(gameObject);
	}
}

