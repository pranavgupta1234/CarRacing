using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour {

	public GameObject[] cars;
	public float maxPos = 2.15f;
	public float timer;
	public float delayTimer = 1f;
	int carNo;

	// Use this for initialization
	void Start () {
		timer = delayTimer;
	}
	
	// Update is called once per frame
	void Update () {

		timer -= Time.deltaTime;

		if (timer <= 0) {
			Vector3 randCarPos = new Vector3 (Random.Range (-maxPos, maxPos), transform.position.y, transform.position.z);
			carNo = Random.Range (0, 6);
			Instantiate (cars[carNo], randCarPos, transform.rotation); 
			timer = delayTimer;
		}
	}
}
