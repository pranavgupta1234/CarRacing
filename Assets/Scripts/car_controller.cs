using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class car_controller : MonoBehaviour {
		
	public float carSpeed;
	public Vector3 position;
	public float maxPos = 2.15f;

	public UIManage uimanage;
	public AudioManager audiomanager;
	bool currentPlatformAndroid = true;
	public Rigidbody2D rb;


	#if UNITY_ANDROID

	#else 
			currentPlatfromAnroid = false;
	#endif

	void Awake(){
		audiomanager.carSound.Play ();
	}

	// Use this for initialization
	void Start () {
		uimanage = uimanage.GetComponent<UIManage> ();
		if (uimanage == null) {
			Debug.Log ("ye toh null h bc");
		}
		position = transform.position;
		rb = GetComponent<Rigidbody2D> ();
		if (currentPlatformAndroid) {
			Debug.Log ("Android");
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (currentPlatformAndroid) {
			TouchMove ();
		
		} else {
			position.x += Input.GetAxis ("Horizontal") * carSpeed * Time.deltaTime;
		}
		position.x = Mathf.Clamp (position.x, -maxPos, maxPos);
		transform.position = position;
	}

	void OnCollisionEnter2D(Collision2D col){
		Debug.Log ("Collided");
		if(col.gameObject.tag == "Enemy"){
			try{
				uimanage.gameFinish ();
				Destroy (gameObject);
				audiomanager.carSound.Stop();
				audiomanager.explosion.Play();
			}catch(NullReferenceException ex){
				Debug.Log ("Null");
			}
		}
	}

	public void moveLeft(){
		rb.velocity = new Vector2 (-carSpeed, 0);
	}

	public void moveRight(){
		rb.velocity = new Vector2 (carSpeed, 0);	
	}

	public void setVelocityZero(){
		rb.velocity = Vector2.zero;
	}

	public void TouchMove(){
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch (0);
			float middle = Screen.width / 2;

			if (touch.position.x < middle && touch.phase == TouchPhase.Began) {
				moveLeft ();
			} else if(touch.position.x > middle && touch.phase == TouchPhase.Began) {
				moveRight ();
			}
		
		}else{
			setVelocityZero();
		}
		
	}

}
