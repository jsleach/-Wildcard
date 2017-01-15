using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		// Zooming
		if (Input.GetKey (KeyCode.Equals)) {
			var direction = transform.position;
			direction.Normalize ();
			transform.position -= (direction * speed/2);
		} else if (Input.GetKey (KeyCode.Minus)) {
			var direction = transform.position;
			direction.Normalize ();
			transform.position += (direction * speed/2);
		}

		// Left/right rotation
		transform.RotateAround(new Vector3(0, 0, 0), new Vector3(0.0f, 1.0f, 0.0f), -moveHorizontal * speed);

		// up/down rotation
		var angle = Vector3.Angle(new Vector3(0, 1, 0), transform.position);
		if( (moveVertical < 0 && angle <= 88) || (moveVertical > 0 && angle >= 2)) {
			var horizAxis = new Vector3(-transform.position.z, 0, transform.position.x);
			transform.RotateAround (new Vector3 (0, 0, 0), horizAxis, moveVertical * speed);
		}

		// look at center
		transform.LookAt (new Vector3(0, 0, 0));

		
	}
}
