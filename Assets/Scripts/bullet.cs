using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

	public Vector3			shooter;
	public AudioSource		son;
	public static bool		end = false;

	void Start ()
	{
		shooter = player.dir2;
	}

	void Update ()
	{
		//son.Play();

		float AngleRad = Mathf.Atan2(shooter.y, shooter.x);
		float AngleDeg = (180 / Mathf.PI) * AngleRad;
		this.transform.rotation = Quaternion.Euler(0, 0, (AngleDeg + 84));
		Debug.Log("Player Angle: " + AngleDeg);

		transform.Translate(Vector3.down * Time.deltaTime * 7);

		if (end)
		{
			Destroy(gameObject);
			end = false;
		}
	}

	public void		OnCollisionEnter2D(Collision2D col)
	{
		//Debug.Log("Collisio: " + col.gameObject.name);
		end = true;
		player.bastos = false;
	}
}

