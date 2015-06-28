using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	private Rigidbody rb;
	public float Speed;

	void Start () {
		rb = GetComponent<Rigidbody>();

		rb.velocity = transform.forward * Speed;
		rb.angularVelocity = transform.eulerAngles*Speed;
	}
	

}
