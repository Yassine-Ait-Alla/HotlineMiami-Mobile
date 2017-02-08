using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour
{
	public static bool			agro = false;

	public Vector3				target;
	public float				angle;
	public Quaternion			quat;


	public GameObject			fire;
	public GameObject			Pfire;

	public static bool			bastos = false;

	void Start ()
	{
	}
	
	void Update ()
	{
		if (agro)
		{
			target = player.pp.position;
			Vector3 dir = target - transform.position;
			angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);

			transform.Translate(Vector3.down * Time.deltaTime * 1.2f);

			if (bastos == false)
			{
				fire = (GameObject)GameObject.Instantiate(Pfire, transform.position, Quaternion.identity);
				Physics2D.IgnoreCollision(fire.GetComponent<Collider2D>(), GetComponent<Collider2D>());
				bastos = true;
			}

			//Shoot();
			/*
			angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
			quat = Quaternion.AngleAxis(angle, Vector3.back);
			transform.rotation = Quaternion.Slerp(transform.rotation, quat, Time.deltaTime * 2f);
			*/


		//	Debug.Log(transform.rotation);

			
		}
	}


	public void		OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.name == "bullet(Clone)")
			Destroy(gameObject);
	}

	/*
	public void		Shoot()
	{
	}
	*/

	public void		OnTriggerEnter2D(Collider2D col)
	{
		/*
		if (col.gameObject.name == "Hero")
			Destroy(gameObject);
			*/
	}
}
