using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	
	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	
	private bool gameOver;
	private bool restart;
	private int score;
	public int newSpeed=0;
	
	void Start ()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}
	
	void Update ()
	{
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{

			for (int i = 0; i < hazardCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				GameObject  colone =Instantiate(hazard, spawnPosition, spawnRotation) as GameObject;
				colone.GetComponent<Mover>().Speed -=newSpeed;
			  	yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			Harder();



			if (gameOver)
			{
				restartText.text = "Press 'R' for Restart";
				restart = true;
			//	hazard.GetComponent<Mover>().Speed =-5;
				break;
			}
		}
	}


	void Harder()
	{
		if (newSpeed < 10)
			newSpeed++;

		if (spawnWait > 0.3) {
			spawnWait -= 0.1f;
		}

    	if(waveWait>1)
		  waveWait-=0.5f;

		if (hazardCount < 20)
			hazardCount++;
	}


	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	
	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}
	
	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
		newSpeed = 0;
	}
}