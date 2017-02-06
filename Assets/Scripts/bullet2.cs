using UnityEngine;
using System.Collections;

public class bullet2 : MonoBehaviour {

	//public AudioSource	son;
	public static bool		end = false;
	public bool 			shooting = false;
	
	public Vector3			target;
	public Vector3			targ;

	void Start ()
	{
		target = player.pp.position;
		targ = transform.position;
	}

	void Update ()
	{
		Shoot();
	}

	public void		Shoot()
	{

		if (enemy.agro)
		{
			Vector3 dir = (target - targ);

			dir = (dir.magnitude > 1) ? dir.normalized : dir;

			float AngleRad = Mathf.Atan2(dir.y, dir.x);
			float AngleDeg = (180 / Mathf.PI) * AngleRad;
			this.transform.rotation = Quaternion.Euler(0, 0, (AngleDeg + 84));

			transform.Translate(Vector3.down * Time.deltaTime * 7);
		
			/*
			float	angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

			transform.Translate(Vector3.right * Time.deltaTime * 7);
			*/

			if (end || player.life < 1)
			{
				Destroy(gameObject);
				end = false;
			}
		}
	}

	public void		OnCollisionEnter2D(Collision2D col)
	{
		/*
		Debug.Log(col.gameObject.name);
		if (col.gameObject.name == "Hero");
		{
			player.life--;
			GameObject.Find("lifeRect" + player.life).SetActive(false);
		}
		*/
		end = true;
		enemy.bastos = false;
	}
}

