using UnityEngine;
using System.Collections;

public class DestoryByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject PlayerExplosion;
	public int ScoreValue;
	private GameController gameController;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if (gameController == null) {
			Debug.Log("Cannot find GameController Script!");
		}
	}


    void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Boundary") {
			return;
		}
		Instantiate (explosion, transform.position, transform.rotation);

		if (other.tag == "Player") {
			Instantiate (PlayerExplosion, transform.position, transform.rotation);
			gameController.GameOver();
		}
		gameController.AddScore (ScoreValue);

		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
