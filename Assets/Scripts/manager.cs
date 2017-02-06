using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class manager : MonoBehaviour
{
	private static manager		instance;
	public static manager		Instance{get{return instance;}}

	public int					currentLVL = 1;
	public int					scoreMax = 0;


	private void Awake()
	{
		instance = this;
		DontDestroyOnLoad(gameObject);
		
		if (PlayerPrefs.HasKey("CurrentLVL"))
		{
			currentLVL = PlayerPrefs.GetInt("CurrentLVL");
			scoreMax = PlayerPrefs.GetInt("ScoreMax");
		}
		else
			Save();

	}

	public void		LoadNewGame()
	{
		currentLVL = 1;
		scoreMax = 0;
		SceneManager.LoadScene("1_level");
	}

	public void		Save()
	{
		PlayerPrefs.SetInt("CurrentLVL", currentLVL);
		PlayerPrefs.SetInt("ScoreMax", scoreMax);
	}

	public void		Continue()
	{
		SceneManager.LoadScene(currentLVL.ToString() + "_level");
	}

	/*
	void Start ()
	{}
	
	void Update ()
	{}
	*/
}
