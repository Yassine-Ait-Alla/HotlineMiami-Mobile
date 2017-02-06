using UnityEngine;
using System.Collections;

public class player : MonoBehaviour
{

	public VirtualJoystick			moveJoystick;
	public VirtualJoystick			shooter;
	public GameObject				Pfire;
	public GameObject				fire;
	public float					delay = 0.1f;
	public static int				life = 4;
	public int						haha = 50;


	public static Transform			pp;
	public static Vector3			dir2 = Vector3.zero;
	public Vector3					dir = Vector3.zero;

	//private IEnumerator				routine = null;
	
	public static bool						bastos = false;

	void FixedUpdate ()
	{
		pp = transform;
		dir = Vector3.zero;

		//Move player
		Move();

		//Shoot action
		Shoot();

		if (Input.GetKey ("d"))
			transform.Translate(Vector2.right * (5 * Time.deltaTime), Space.World);
		if (Input.GetKey ("a"))
			transform.Translate(Vector2.left * (5 * Time.deltaTime), Space.World);
		if (Input.GetKey ("w"))
			transform.Translate(Vector2.up * (5 * Time.deltaTime), Space.World);
		if (Input.GetKey ("s"))
			transform.Translate(Vector2.down * (5 * Time.deltaTime), Space.World);

		transform.Translate(dir / 8);
		//transform.Translate(transform.position.x, transform.position.y, 0);

		Die();
	}


	public void Die()
	{
		if (life < 1)
		{
			transform.Rotate(Vector3.forward * Time.deltaTime * 1850);
			haha--;
		}
		if (haha < 1)
		{
			Destroy(gameObject);
			enemy.agro = false;
		}
	}

	public void	Move()
	{
		float		ajust = transform.rotation.z;

		Debug.Log(moveJoystick.InputDirection.z);
		//Debug.Log(transform.rotation.z);
		if (moveJoystick.InputDirection != Vector3.zero)
		{
			//dir = moveJoystick.InputDirection.normalized;
			dir.x = moveJoystick.InputDirection.x - transform.rotation.x;
			dir.y = moveJoystick.InputDirection.y - transform.rotation.y;
			/*
			if (ajust > 0)
				dir.z -= ajust;
			else
				dir.z += ajust;
				*/
		}
	}

	public void	Shoot()
	{
		Vector3		pos = this.transform.position;

		if (shooter.InputDirection != Vector3.zero)
		{
			//shoot direction
			dir2 = shooter.InputDirection;
			float AngleRad = Mathf.Atan2(dir2.y, dir2.x);
			float AngleDeg = (180 / Mathf.PI) * AngleRad;
			this.transform.rotation = Quaternion.Euler(0, 0, (AngleDeg + 84));
			moveJoystick.transform.rotation = Quaternion.Euler(0, 0, (AngleDeg + 84));

			if (bastos == false)
			{
				fire = (GameObject)GameObject.Instantiate(Pfire, pos, Quaternion.identity);
				Physics2D.IgnoreCollision(fire.GetComponent<Collider2D>(), GetComponent<Collider2D>());
				bastos = true;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		//Debug.Log(col.gameObject.name);
		if (col.gameObject.name == "bullet2(Clone)")
		{
			life--;
			GameObject.Find("lifeRect" + life).SetActive(false);
		}
			//Debug.Log("lol");
	}

	/*
	IEnumerator		shoot(Vector3 pos, Vector3 dir)
	{
		fire = (GameObject)GameObject.Instantiate(Pfire, pos, Quaternion.identity);

		fire.transform.Translate(dir * Time.deltaTime * 10);

		yield return new WaitForSeconds(delay);
		GameObject.Destroy(fire);
		this.routine = null;
	}
	*/
}
